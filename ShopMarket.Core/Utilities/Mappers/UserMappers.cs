using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Utilities.Mappers
{
    public static class UserMappers
    {
        public static UserViewModel MapToViewModel(this User user)
        {
            return new UserViewModel()
            {
                UserId = user.Id,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                UserAvatar = user.UserAvatar,
                Email = user.Email,
                FullName = user.FullName,
                IsEmailVerified = user.IsEmailVerified,
                NationalCode = user.NationalCode,
                ReceiveNews = user.ReceiveNews,
                ActiveCode = user.ActiveCode,
                RegisterDate = user.CreationDate
            };
        }

        public static User MapToUser(this UserViewModel userVm)
        {
            return new User()
            {
                Id = userVm.UserId,
                PhoneNumber = userVm.PhoneNumber,
                Password = userVm.Password,
                UserAvatar = userVm.UserAvatar,
                Email = userVm.Email,
                FullName = userVm.FullName,
                IsEmailVerified = userVm.IsEmailVerified,
                NationalCode = userVm.NationalCode,
                ReceiveNews = userVm.ReceiveNews,
                ActiveCode = userVm.ActiveCode
            };
        }

        public static UserAddressViewModel MapToViewModel(this UserAddress userAddress)
        {
            return new UserAddressViewModel()
            {
                UserId = userAddress.UserId,
                AddressId = userAddress.AddressId,
                FullAddress = userAddress.FullAddress,
                State = userAddress.State,
                City = userAddress.City,
                Street = userAddress.Street,
                Plaque = userAddress.Plaque,
                IsSelectedAddress = userAddress.IsSelectedAddress,
                ReceiverName = userAddress.ReceiverName,
                ReceiverPhone = userAddress.ReceiverPhone
            };
        }

        public static UserAddress MapToAddress(this UserAddressViewModel userAddressViewModel)
        {
            return new UserAddress()
            {
                UserId = userAddressViewModel.UserId,
                AddressId = userAddressViewModel.AddressId,
                FullAddress = userAddressViewModel.FullAddress,
                State = userAddressViewModel.State,
                City = userAddressViewModel.City,
                Street = userAddressViewModel.Street,
                Plaque = userAddressViewModel.Plaque,
                IsSelectedAddress = userAddressViewModel.IsSelectedAddress,
                ReceiverName = userAddressViewModel.ReceiverName,
                ReceiverPhone = userAddressViewModel.ReceiverPhone
            };
        }

        public static RecentVisitViewModel MapToViewModel(this RecentVisit useRecentVisit)
        {
            int price = (int)((useRecentVisit.Product.Discount.HasValue)
                ? ((useRecentVisit.Product.Price * useRecentVisit.Product.Discount.Value) / 100)
                : useRecentVisit.Product.Price);

            return new RecentVisitViewModel()
            {
                Price = price,
                UserId = useRecentVisit.UserId,
                ProductId = useRecentVisit.ProductId,
                Title = useRecentVisit.Product.Title,
                RecentVisitId = useRecentVisit.RecentVisitId,
                Score = useRecentVisit.Product.Score
            };
        }
        
    }
}
