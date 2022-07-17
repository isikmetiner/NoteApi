using NoteAPI.Models;

namespace NoteAPI.Repository.Abstracts
{
    public interface IUsersRepository
    {
        bool IsUserExistId(int id);
        bool IsUserExistUsername(string username);
        int GetUserCount();
        ICollection<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User LoginAuthentication(string username, string password);
    }
}
