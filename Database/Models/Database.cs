using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Database.Models
{
    public class Database
    {
        string CONN = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public DataSet RunProcedure(string proc, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(CONN);
            SqlCommand cmd = new SqlCommand(proc,connection);
            cmd.CommandTimeout = 600;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters.ToArray());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public List<Type> GetProcedure(string proc, object model)
        {
            List<Type> res = new List<Type>();
            return res;
        }
        public List<SqlParameter> BuildParams(object model)
        {
            model.GetType();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            PropertyInfo[] properties = model.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                //property.SetValue(record, value);
                sqlParameters.Add(new SqlParameter("@" + property.Name, property.GetValue(model)));
            }
            return sqlParameters;
        }
        public List<Type> BuildResult(DataSet set, Type type)
        {
            List<Type> res = new List<Type>();
            PropertyInfo[] properties = type.GetProperties();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                foreach (PropertyInfo property in properties)
                {

                }
            }
            return res;
        }
        //public List<Type> RunGetProcedure(Func func, string procName)
        //{

        //}
    }
}