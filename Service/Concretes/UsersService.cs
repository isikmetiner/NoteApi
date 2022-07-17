using NoteAPI.Models;
using NoteAPI.Service.Abstract;
using NoteAPI.Repository.Abstracts;

namespace NoteAPI.Service.Concretes
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersService)
        {
            _usersRepository = usersService;
        }
        public bool IsUserExistId(int id)
        {
            return _usersRepository.IsUserExistId(id);
        }

        public bool IsUserExistUsername(string username)
        {
            return _usersRepository.IsUserExistUsername(username);
        }

        public int GetUserCount()
        {
            return _usersRepository.GetUserCount();
        }

        public ICollection<User> GetAllUsers()
        {
            return _usersRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _usersRepository.GetUserById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _usersRepository.GetUserByUsername(username);
        }

        public void CreateUser(User user)
        {
            _usersRepository.CreateUser(user);
        }

        public void UpdateUser(int id, User user)
        {
            if (_usersRepository.IsUserExistId(id))
            {
                User updatedUser = _usersRepository.GetUserById(id);
                updatedUser.Username = user.Username;
                updatedUser.Password = user.Password;
                _usersRepository.UpdateUser(updatedUser);
            }
        }

        public void DeleteUser(int id)
        {
            if (_usersRepository.IsUserExistId(id))
            {
                User user = _usersRepository.GetUserById(id);
                _usersRepository.DeleteUser(user);
            }
        }

        public User LoginAuthentication(string username, string password)
        {
            return _usersRepository.LoginAuthentication(username, password);
        }
    }
}
