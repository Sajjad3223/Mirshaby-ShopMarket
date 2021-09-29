using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.Interfaces.UserInterfaces
{
    public interface IUserRoleRepository
    {
        IQueryable<UserRole> GetAll();
        IQueryable<User> GetUsersByRole(int roleId);
        IQueryable<Role> GetRolesByUser(int userId);

        Task<UserRole> GetUserRole(int userRoleId);

        void InsertUserRole(UserRole userRole);
                   
        void UpdateUserRole(UserRole userRole);
                   
        void DeleteUserRole(UserRole userRole);
                   
        void DeleteUserRole(int id);

        void Save();
        IQueryable<UserRole> GetUserRolesOfUser(int userId);
    }
}