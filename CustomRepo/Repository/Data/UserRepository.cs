using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomRepo.Repository;

namespace CustomRepo.Repository.Data
{
    class UserRepository : GeneralRepository
    {
        public UserRepository()
        {
            tableName = "userTable";
        }
    }
}
