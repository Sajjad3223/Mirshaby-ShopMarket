using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Services.UserServices
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        
        public OperationResult Delete(Role role)
        {
            try
            {
                if(role == null)
                    return OperationResult.NotFound();
                _roleRepository.DeleteRole(role);
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
                _roleRepository.DeleteRole(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
            
        }

        public IQueryable<Role> GetDeletedRoles()
        {
            return _roleRepository.GetDeletedRoles();
        }

        public Task<Role> Get(int id)
        {
            if (id == null)
                return null;
            return _roleRepository.GetRole(id);
        }

        public IQueryable<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public int Insert(Role role)
        {
            return _roleRepository.InsertRole(role);
        }
        
        public OperationResult Update(Role role)
        {
            try
            {
                if (role == null)
                    return OperationResult.Error();
                _roleRepository.UpdateRole(role);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}