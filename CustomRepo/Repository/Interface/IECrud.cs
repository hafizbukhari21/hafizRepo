using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRepo.Repository.Interface
{
    interface IECrud
    {
        public int Insert(List<string> input);
        public int Update(int id, Dictionary<string, string> input);
        public int Delete(int id);
        public  SqlDataReader GetAll() ;

    }
}
