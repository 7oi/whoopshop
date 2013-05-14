using System;
namespace Bordspil.DAL
{
    interface IUserRepository
    {
        void DeleteUser(int userID);
        User GetUserByID(int id);
        System.Collections.Generic.IEnumerable<User> GetUsers();
        void InsertUser(User user);
    }
}
