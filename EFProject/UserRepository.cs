using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFProject
{
    public static class UserRepository
    {
        private static AppContext db;

        public static bool IsEmpty()
        {
            using (db = new AppContext())
            {                
                return db.Users.Count() == 0;
            }
        }
        public static void AddUser(User user)
        {
            using (db = new AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static void AddUserRange(IEnumerable<User> users)
        {
            using (db = new AppContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }

        public static List<User> GetAllUsers()
        {
            using (db = new AppContext())
            {
                var allUsers = db.Users.ToList();
                return allUsers;
            }
        }

        public static User GetUserById(int id)
        {
            using (db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == id);
                return user;
            }
        }

        public static void DeleteUserById(int id)
        {
            using (db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                    db.Users.Remove(user);
                else throw new Exception($"Пользователь с Id {id} не существует");
                db.SaveChanges();
            }
        }

        public static void UpdateUserNameById(int id, string name)
        {
            using (db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                    user.Name = name;
                else throw new Exception($"Пользователь с Id {id} не существует");
                db.SaveChanges();
            }
        }

        public static void TakeBookOnHands(int userId, int bookId)
        {
            using (db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if(user != null) 
                    user.Books.Add(db.Books.FirstOrDefault(b => b.Id == bookId));
                else throw new Exception($"Пользователь с Id {userId} не существует");
                db.SaveChanges();
            }
        }
    }
}
