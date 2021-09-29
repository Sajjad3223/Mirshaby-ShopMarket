using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Services.UserServices
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public OperationResult DeleteUserRole(UserRole userRole)
        {
            try
            {
                if (userRole == null)
                    return OperationResult.NotFound();
                _userRoleRepository.DeleteUserRole(userRole);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteUserRole(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _userRoleRepository.DeleteUserRole(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public Task<UserRole> GetUserRole(int id)
        {
            if (id == null)
                return null;
            return _userRoleRepository.GetUserRole(id);
        }

        public IQueryable<UserRole> GetAll()
        {
            return _userRoleRepository.GetAll();
        }

        public OperationResult InsertUserRole(UserRole userRole)
        {
            try
            {
                if (userRole == null)
                    return OperationResult.Error();
                _userRoleRepository.InsertUserRole(userRole);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
        
        public IQueryable<Role> GetRolesByUser(int userId)
        {
            if (userId == null)
                return null;
            return _userRoleRepository.GetRolesByUser(userId);
        }

        public IQueryable<User> GetUsersByRole(int roleId)
        {
            if (roleId == null)
                return null;
            return _userRoleRepository.GetUsersByRole(roleId);
        }

        public void AddRolesToUser(List<int> roles, int userId)
        {
            foreach (var roleId in roles)
            {
                InsertUserRole(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }
            _userRoleRepository.Save();
        }

        public void UpdateUserRoles(List<int> roles, int userId)
        {
            var userRoles = GetUserRolesOfUser(userId).ToList();
            userRoles.ForEach(ur=>DeleteUserRole(ur));
            AddRolesToUser(roles,userId);
        }

        public IQueryable<UserRole> GetUserRolesOfUser(int userId)
        {
            return _userRoleRepository.GetUserRolesOfUser(userId);
        }
    }
}