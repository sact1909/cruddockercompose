using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cruddockercompose.DbEntities.DbModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
