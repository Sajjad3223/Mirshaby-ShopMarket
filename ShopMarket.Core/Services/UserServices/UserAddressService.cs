using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Services.UserServices
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepository _userAddressRepository;

        public UserAddressService(IUserAddressRepository userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
        }

        public OperationResult ChangeActiveAddress(int addressIdToActive,int userId)
        {
            try
            {
                IList<UserAddressViewModel> userAddresses = GetUserAddresses(userId).ToList();
                foreach (var address in userAddresses)
                {
                    address.IsSelectedAddress = (address.AddressId == addressIdToActive);
                    Update(address);
                }
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult Delete(UserAddressViewModel address)
        {
            try
            {
                if(address == null)
                    return OperationResult.NotFound();
                _userAddressRepository.DeleteAddress(address.MapToAddress());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult Delete(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _userAddressRepository.DeleteAddress(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public async Task<UserAddressViewModel> Get(int id)
        {
            return (await _userAddressRepository.GetAddress(id)).MapToViewModel();
        }

        public async Task<UserAddressViewModel> GetUserActiveAddress(int userId)
        {
            var address = await _userAddressRepository.GetUserActiveAddress(userId);
            if(address != null)
                return address.MapToViewModel();
            return null;
        }

        public IQueryable<UserAddressViewModel> GetUserAddresses(int userId)
        {
            return _userAddressRepository.GetUserAddresses(userId).Select(a=>a.MapToViewModel());
        }

        public OperationResult Insert(UserAddressViewModel address)
        {
            try
            {
                if (address == null)
                    return OperationResult.NotFound();
                _userAddressRepository.InsertAddress(address.MapToAddress());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult Update(UserAddressViewModel address)
        {
            try
            {
                if (address == null)
                    return OperationResult.NotFound();
                _userAddressRepository.UpdateAddress(address.MapToAddress());
                return OperationResult.Success();
            }
            catch (Exception e)
            {
                return OperationResult.Error();
            }
        }
    }
}