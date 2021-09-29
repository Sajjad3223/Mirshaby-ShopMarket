using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Interfaces.UserInterfaces
{
    public interface IUserService
    {
        UsersDto GetAll(Filter filter);

        IQueryable<UserViewModel> GetDisabledUsers();

        Task<UserViewModel> GetUser(int id);

        Task<UserViewModel> GetUserByPhone(string phoneNumber);

        Task<UserViewModel> GetUserByActiveCode(string code);

        Task<UserViewModel> GetUserByEmail(string email);

        Task<OperationResult> InsertUser(RegisterViewModel userRegister);

        OperationResult UpdateUser(UserViewModel userViewModel);

        OperationResult DeleteUser(User user);

        Task<CheckUserStatus> CheckUser(string phone,string email);

        Task<bool> DoesUserExist(LoginViewModel userLogin);

        Task<OperationResult> DeleteUser(int id);

        Task<bool> ActiveAccount( string activeCode);
        Task<OperationResult> ReActivateUser(int id);
    }

    public enum CheckUserStatus
    {
        EmailAndPhoneExist,
        EmailExists,
        PhoneExists,
        DoesNotExist
    }
}