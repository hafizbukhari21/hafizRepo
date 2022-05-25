using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CustomRepo
{
    class Helper
    {
        public static string ConvertListToString(List<string> list) {
            return  "'"+string.Join("','", list.ToArray())+"'";
        }

        public static string ConvertDictionaryAndListToString(Dictionary<string, string> dictionary)
        {
            string dictionaryString = "";
            foreach (KeyValuePair<string, string> keyValues in dictionary)
            {
                dictionaryString += keyValues.Key + " = '" + keyValues.Value + "', ";
            }
            return dictionaryString.TrimEnd(',', ' ') ;
        }

        public static SqlDataReader FunctionExecuteReader(string q, SqlConnection conn)
        {
            try
            {
                conn.Open();
                SqlCommand table = new SqlCommand(q, conn);
                return table.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static int FunctionExecuteNonQuery(string q, SqlConnection conn)
        {
            try
            {
                conn.Open();
                SqlCommand table = new SqlCommand(q, conn);
                int reader = table.ExecuteNonQuery();
                conn.Close();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return 0;

        }
    }
}
