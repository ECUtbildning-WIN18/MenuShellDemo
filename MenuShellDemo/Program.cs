using MenuShellDemo.Domain;
using MenuShellDemo.Domain.View;

namespace MenuShellDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.Users.Add("admin", new User("admin", "secret", "Administrator"));
            Database.Users.Add("johndoe", new User("johndoe", "secret", "Receptionist"));
            Database.Users.Add("janedoe", new User("janedoe", "secret", "Veterinarian"));
            Database.Users.Add("jimdoe", new User("jimdoe", "secret", "Administrator"));
            
            var loginView = new LoginView();

            loginView.Display();
        }
    }
}
