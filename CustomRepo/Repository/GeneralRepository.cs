using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomRepo.Repository.Interface;
using CustomRepo;

namespace CustomRepo.Repository
{
    class GeneralRepository:IECrud
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-U2HEGL6;Initial Catalog=LatihanQuery;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

        protected string tableName;

        public int Delete(int id)
        {
            return Helper.FunctionExecuteNonQuery($"DELETE FROM {tableName} WHERE id={id}", conn); ;
        }

        public SqlDataReader GetAll()
        {
            return Helper.FunctionExecuteReader($"select * from {tableName} ", conn) ;
        }

        public SqlDataReader GetAll(int id)
        {
            return Helper.FunctionExecuteReader($"select * from {tableName} where id = {id}",conn);
        }

        public int Insert(List<string> input)
        {
            string parameter = Helper.ConvertListToString(input);
            return Helper.FunctionExecuteNonQuery($"insert into {tableName} values ({parameter})", conn);
        }

        public int Update(int id, Dictionary<string,string> input)
        {
            string parameter = Helper.ConvertDictionaryAndListToString(input);
            return Helper.FunctionExecuteNonQuery($"Update {tableName} Set {parameter} where id = {id}", conn);

        }
        
    }
}
