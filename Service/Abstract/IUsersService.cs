using NoteAPI.Models;

namespace NoteAPI.Service.Abstract
{
    public interface IUsersService
    {
        bool IsUserExistId(int id);
        bool IsUserExistUsername(string username);
        int GetUserCount();
        ICollection<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void CreateUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
        User LoginAuthentication(string username, string password);
    }
}
