using BetterDDSec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDDSec.Storage
{
    class UserStorage
    {
        static private UserStorage _instance;
        static private object _padlock = new object();

        static public UserStorage Instance
        {
            get
            {
                if (_instance == null)
                    lock (_padlock)
                        if (_instance == null)
                            _instance = new UserStorage();

                return _instance;
            }
        }

        private List<User> _users;

        private UserStorage()
        {
            _users = new List<User>();
        }

        internal void GenerateContent(int numberOfUsers)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                string first = NameGenerator.NameGenerator.GetFirstName(), last = NameGenerator.NameGenerator.GetLastName();

                _users.Add(new User(first, last, $"{first.ToLower()}.{last.ToLower()}@example.com", new Random().Next(1950, 2000)));
            }
        }

        public void AddUser(User user)
        {
            if (!_users.Contains(user, new UserComparer()))
                _users.Add(user);
        }

        public User GetUser(Guid userId)
        {
            return _users.Where(x => x.Id == userId).FirstOrDefault();
        }

        internal void UpdateUser(User user)
        {
            if (_users.Where(x => x.Id == user.Id).FirstOrDefault() != null)
                _users[_users.IndexOf(_users.Where(x => x.Id == user.Id).FirstOrDefault())] = user;
        }

        public User[] GetAllUsers()
        {
            return _users.ToArray();
        }

        public void RemoveUser(User user)
        {
            if (_users.Where(x => x.Id == user.Id).FirstOrDefault() != null)
                _users.Remove(user);
        }

        public class UserComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(User obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
