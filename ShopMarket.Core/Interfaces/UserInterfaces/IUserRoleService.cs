using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Interfaces.UserInterfaces
{
    public interface IUserRoleService
    {
        IQueryable<UserRole> GetAll();

        IQueryable<Role> GetRolesByUser(int userId);
        IQueryable<User> GetUsersByRole(int roleId);
        IQueryable<UserRole> GetUserRolesOfUser(int userId);

        Task<UserRole> GetUserRole(int id);

        OperationResult InsertUserRole(UserRole userRole);

        OperationResult DeleteUserRole(UserRole userRole);

        OperationResult DeleteUserRole(int id);
        
        void AddRolesToUser(List<int> roles, int userId);

        void UpdateUserRoles(List<int> roles, int userId);
    }
}