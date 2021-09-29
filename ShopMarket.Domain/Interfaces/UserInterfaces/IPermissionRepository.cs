using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Domain.Interfaces.UserInterfaces
{
    public interface IPermissionRepository
    {
        IQueryable<Permission> GetAll();

        Task<Permission> GetPermission(int id);

        void InsertPermission(Permission permission);

        void UpdatePermission(Permission permission);

        void DeletePermission(Permission permission);

        void DeletePermission(int id);

        void Save();
    }
}