using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.Interfaces.UserInterfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();

        Task<User> GetUser(int id);

        Task<User> GetUserByPhone(string phone);

        Task<User> GetUserByActiveCode(string code);

        Task<User> GetUserByEmail(string email);

        void InsertUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        Task<bool> DoesPhoneNumberExist(string phone);
        Task<bool> DoesEmailExist(string email);
        Task<bool> DoesUserExist(string phone, string password);

        void DeleteUser(int id);

        IQueryable<User> GetDisabledUsers();
        void ReActivateUser(User user);
    }
}