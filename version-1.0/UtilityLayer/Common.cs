using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using DataLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UtilityLayer
{
    public class Common
    {
        public static int GetNewID(string tableName)
        {
            int newID = 0;
            DLConnection conn = new DLConnection();
            object value;
            string qry = "";
            SqlCommand cmd;
            try
            {
                conn.CreatConnection();

                qry = "SELECT MAX(ID) FROM " + tableName + "";

                cmd = new SqlCommand(qry,conn.con);

                value = cmd.ExecuteScalar();

                if (value != null && value.ToString() != "")
                {
                    newID = Convert.ToInt32(value) + 1;
                }
                else
                {
                    newID = 1;
                }

                return newID;
            }
            catch (Exception ex)
            {
              return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public static string ObtainConfig(string Value)
        {
            string strReturn = "";
            System.Configuration.AppSettingsReader App_Config = new System.Configuration.AppSettingsReader();
            try
            {
                //strReturn =App_Config .GetValue(Value, Value.GetType()).ToString();
                strReturn = System.Configuration.ConfigurationManager.ConnectionStrings[Value].ToString();
            }
            catch (Exception ex)
            {
                ErrorLog("ObtainConfig : " + ex.Message);
                strReturn = "";
            }
            return strReturn;
        }

        public static void ErrorLog(string message)
        {
            ErrorLog(message, ObtainConfig("ErrorLog"));
        }

        public static void ErrorLog(string message, string path)
        {
            System.IO.StreamWriter writer;
            writer = System.IO.File.AppendText(path);
            writer.WriteLine(DateTime.Now.ToString() + ":" + message);
            writer.Flush();
            writer.Close();
        }

        public static bool CheckOpened(string name)
        {
            System.Windows.Forms.FormCollection fc = System.Windows.Forms.Application.OpenForms;

            foreach (System.Windows.Forms.Form frm in fc)
            {
                if (frm.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
