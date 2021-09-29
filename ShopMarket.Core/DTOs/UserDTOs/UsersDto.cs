using System.Collections.Generic;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.DTOs.UserDTOs
{
    public class UsersDto
    {
        public IEnumerable<User> Users { get; set; }

        public int UsersCount { get; set; }

        public Filter Filter { get; set; }
    }
}