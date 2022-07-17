using NoteAPI.Data;
using NoteAPI.Models;
using NoteAPI.Repository.Abstracts;

namespace NoteAPI.Repository.Concretes
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _dataContext;

        public UsersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool IsUserExistId(int id)
        {
            return _dataContext.User.Any(x => x.Id == id);
        }

        public bool IsUserExistUsername(string username)
        {
            return _dataContext.User.Any(x => x.Username == username);
        }

        public int GetUserCount()
        {
            return _dataContext.User.Count();
        }

        public ICollection<User> GetAllUsers()
        {
            return _dataContext.User.ToList();
        }

        public User GetUserById(int id)
        {
            return _dataContext.User.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _dataContext.User.FirstOrDefault(x => x.Username == username);
        }

        public void CreateUser(User user)
        {
            _dataContext.User.Add(user);
            _dataContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dataContext.User.Update(user);
            _dataContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _dataContext.User.Remove(user);
            _dataContext.SaveChanges();
        }

        public User LoginAuthentication(string username, string password)
        {
            return _dataContext.User.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
