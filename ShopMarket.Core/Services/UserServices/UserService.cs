using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Services.FileManager;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Services.UserServices
{
    public class UserService : IUserService
    {
        private const string DefaultUserAvatar = "avatar.png";

        private readonly IUserRepository _userRepository;
        private readonly IFileManager _fileManager;

        public UserService(IUserRepository userRepository, IFileManager fileManager)
        {
            _userRepository = userRepository;
            _fileManager = fileManager;
        }

        public async Task<bool> ActiveAccount(string activeCode)
        {
            var user = (await GetUserByActiveCode(activeCode));

            if (string.IsNullOrWhiteSpace(activeCode) || user == null || user.IsEmailVerified)
                return false;

            user.IsEmailVerified = true;
            user.ActiveCode = Generators.GetRandomCode();
            UpdateUser(user);
            return true;
        }

        public async Task<OperationResult> ReActivateUser(int id)
        {
            var user = await GetUser(id);
            _userRepository.ReActivateUser(user.MapToUser());
            return OperationResult.Success();
        }

        public UsersDto GetAll(Filter filter)
        {
            var users = _userRepository.GetAll();

            int pageCount = 1;

            if (filter != null)
            {
                users = users.Where(u => u.FullName.Contains(filter.Search) ||
                                         u.PhoneNumber.Contains(filter.Search) ||
                                         u.Email.Contains(filter.Search)).Distinct().AsQueryable();
                int skip = (filter.PageId - 1) * filter.Take;
                users = users.Skip(skip).Take(filter.Take);
            }
            else
            {
                filter = new Filter();
            }

            pageCount = users.Count() / filter.Take;

            return new UsersDto()
            {
                Filter = filter,
                Users = users,
                UsersCount = pageCount
            };
        }

        public IQueryable<UserViewModel> GetDisabledUsers()
        {
            return _userRepository.GetDisabledUsers().Select(p => p.MapToViewModel());
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            if (id == null)
                return null;
            var user = await _userRepository.GetUser(id);
            return user.MapToViewModel();
        }

        public async Task<OperationResult> InsertUser(RegisterViewModel userRegister)
        {
            try
            {
                if (userRegister == null)
                    return OperationResult.Error();
                if (await CheckUser(userRegister.PhoneNumber, userRegister.Email) != CheckUserStatus.DoesNotExist)
                    return OperationResult.Error("ایمیل و یا شماره همراه وارد شده موجود است");

                _userRepository.InsertUser(new User()
                {
                    FullName = userRegister.FullName,
                    Email = userRegister.Email.FixEmail(),
                    PhoneNumber = userRegister.PhoneNumber,
                    Password = userRegister.Password.EncodeToMd5(),
                    ActiveCode = Generators.GetRandomCode(4),
                    UserAvatar = DefaultUserAvatar
                });

                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult UpdateUser(UserViewModel userViewModel)
        {
            try
            {
                if (userViewModel == null)
                    return OperationResult.NotFound();
                if (userViewModel.AvatarFile != null)
                {
                    if (userViewModel.UserAvatar != DefaultUserAvatar)
                        if (!_fileManager.DeleteFile(Directories.UserImage, userViewModel.UserAvatar))
                            return OperationResult.Error("سرور نتوانست عکس قبلی را حذف کند");
                        
                    string avatarName = _fileManager.SaveFileTo(userViewModel.AvatarFile, Directories.UserImage);
                    userViewModel.UserAvatar = avatarName;
                }
                _userRepository.UpdateUser(userViewModel.MapToUser());
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteUser(User user)
        {
            try
            {
                if (user == null)
                    return OperationResult.NotFound();
                _userRepository.DeleteUser(user);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }

        }

        public async Task<CheckUserStatus> CheckUser(string phone, string email)
        {
            bool emailExist = await _userRepository.DoesEmailExist(email.FixEmail());

            bool phoneExist = await _userRepository.DoesPhoneNumberExist(phone);

            if (emailExist && phoneExist)
                return CheckUserStatus.EmailAndPhoneExist;
            else if (emailExist && !phoneExist)
                return CheckUserStatus.EmailExists;
            else if (!emailExist && phoneExist)
                return CheckUserStatus.PhoneExists;
            else
                return CheckUserStatus.DoesNotExist;
        }

        public Task<bool> DoesUserExist(LoginViewModel userLogin)
        {
            return _userRepository.DoesUserExist(userLogin.PhoneNumber, userLogin.Password.EncodeToMd5());
        }

        public async Task<OperationResult> DeleteUser(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                var user = await GetUser(id);
                _userRepository.DeleteUser(user.MapToUser());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
        
        public async Task<UserViewModel> GetUserByPhone(string phoneNumber)
        {
            return (await _userRepository.GetUserByPhone(phoneNumber)).MapToViewModel();
        }

        public async Task<UserViewModel> GetUserByActiveCode(string code)
        {
            return (await _userRepository.GetUserByActiveCode(code)).MapToViewModel();
        }

        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            return (await _userRepository.GetUserByEmail(email)).MapToViewModel();
        }
        
    }
}