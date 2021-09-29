using System;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.Interfaces.UserInterfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAll();

        Task<Role> GetRole(int roleId);

        int InsertRole(Role role);

        void UpdateRole(Role role);

        void DeleteRole(Role role);

        void DeleteRole(int id);

        void Save();
        IQueryable<Role> GetDeletedRoles();
    }
}