using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShellDemo.Domain
{
    class Database
    {
        public static Dictionary<string, User> Users { get; set; } = new Dictionary<string, User>();
    }
}
