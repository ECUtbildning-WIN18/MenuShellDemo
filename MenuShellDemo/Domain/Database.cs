using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MenuShellDemo.Domain
{
    class Database
    {
        public static Dictionary<string, User> Users { get; set; } = new Dictionary<string, User>();

        public static Dictionary<string, User> GetUsersStartingWithString(string searchString)
        {
            var resultList = Users.Where(x => x.Key.StartsWith(searchString)).ToDictionary(x => x.Key, x => x.Value);

            return resultList;
        }

        public static int PrintUserList(Dictionary<string, User> userList)
        {
            var x = 0;
            foreach (var user in userList)
            {
                x++;
                Console.WriteLine($"{x}. {user.Value.Username,-15}");
            }
            return x;
        }

        public static void DeleteUserFromList(Dictionary<string, User> userList, string username)
        {
            userList.Remove(username);
        }

        //---------------SQL Database--------------------------

        public static Dictionary<string, User> GetUsersFromDb()
        {
            using (var context = new MenuShellDbContext())
            {
                return context.Users.ToDictionary(x => x.Username);
            }
        }

        public static void PrintUserListDb(Dictionary<string, User> myDictionary)
        {
            foreach (var user in myDictionary)
            {
                Console.WriteLine($"{user.Value.Username} {user.Value.Role}");
            }
        }

        //public Dictionary<string, User> ListUsersFromDB(string searchString)
        //{
        //    var resultList = new Dictionary<string, User>();
        //    var queryString = "SELECT * FROM Users";

        //    using (var connection = SqlConnect.Connection())
        //    {
        //        var sqlCommand = new SqlCommand(queryString, connection);

        //        try
        //        {
        //            connection.Open();

        //            var reader = sqlCommand.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                var username = reader["UserName"].ToString();
        //                var password = reader["Password"].ToString();
        //                var role = reader["Role"].ToString();
        //                resultList.Add(username, new User(username, password, role));
        //            }

        //            reader.Close();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //    }

        //    return resultList;
        //}

        public Dictionary<string, User> GetUsersStartingWithStringDb(string searchString)
        {
            var userDictionary = Database.GetUsersFromDb();
            var usersFromDb = userDictionary.Where(x => x.Key.ToLower().StartsWith(searchString.ToLower())).ToDictionary(x => x.Key, x => x.Value);
            return usersFromDb;
        }

        //public Dictionary<string, User> GetUsersStartingWithStringDb(string searchString)
        //{
        //    var resultList = new Dictionary<string, User>();
        //    var queryString = $"SELECT * FROM Users WHERE UserName LIKE '{searchString}%'";

        //    using (var connection = SqlConnect.Connection())
        //    {
        //        var sqlCommand = new SqlCommand(queryString, connection);

        //        try
        //        {
        //            connection.Open();

        //            var reader = sqlCommand.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                var username = reader["Username"].ToString();
        //                var password = reader["Password"].ToString();
        //                var role = reader["Role"].ToString();
        //                resultList.Add(username, new User(username, password, role));
        //            }

        //            reader.Close();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //    }

        //    return resultList;
        //}

        public void AddUserToDb(User user)
        {
            using (var context = new MenuShellDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        //public void AddUserToDB(User user)
        //{
        //    var queryString = $"INSERT INTO Users (UserName, Password, Role) " +
        //                      $"VALUES('{user.Username}', '{user.Password}', '{user.Role}')";

        //    using (var connection = SqlConnect.Connection())
        //    {
        //        try
        //        {
        //            connection.Open();
        //            var sqlCommand = new SqlCommand(queryString, connection);
        //            sqlCommand.ExecuteNonQuery();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //    }
        //}

        public void DeleteUserFromDb(string username)
        {
            using (var context = new MenuShellDbContext())
            {
                var deleteUser = context.Users.Where(x => x.Username == username).FirstOrDefault();
                context.Users.Remove(deleteUser);
                context.SaveChanges();
            }
        }

        //public void DeleteUserFromDB(string username)
        //{
        //    var queryString = $"DELETE FROM Users WHERE UserName = '{username}'";

        //    using (var connection = SqlConnect.Connection())
        //    {
        //        try
        //        {
        //            connection.Open();
        //            var sqlCommand = new SqlCommand(queryString, connection);
        //            sqlCommand.ExecuteNonQuery();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //    }
        //}
    }
}
