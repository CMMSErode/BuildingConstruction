using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilityLayer;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DLCompany
    {
        static DLConnection conn = new DLConnection();
        public static DataView FetchAll()
        {
            SqlCommand cmd;
            string qry = "";
            DataView dv;
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                conn.CreatConnection();

                qry = " SELECT * FROM Company ";

                cmd = new SqlCommand(qry, conn.con);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Company");

                dv = ds.Tables[0].DefaultView;
                return dv;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompany - FetchAll");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public static DataView FetchLikeDatas(int ID = 0, string Code = "", string like = "")
        {
            SqlCommand cmd;
            string qry = "";
            DataView dv;
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Company  WHERE ";

                if (like == "")
                {
                    if (Code != "")
                        qry = qry + " Code =@Code ";
                    else if (ID > 0)
                        qry = qry + " ID =@ID";
                    else
                        qry = qry + " ID =@ID";
                }
                else
                {
                    qry = qry + " Code like '% @Code %' OR ID like '% @ID %'";
                }

                cmd = new SqlCommand(qry, conn.con);
                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Code", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Code;
                cmd.Parameters.Add(param);

                foreach (SqlParameter Parameter in cmd.Parameters)
                {
                    if (Parameter.Value == null)
                    {
                        Parameter.Value = DBNull.Value;
                    }
                }

                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Company");

                dv = ds.Tables[0].DefaultView;
                return dv;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompany - FetchLikeDatas");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public static ELCompany FetchByID(int ID = 0, string Code = "")
        {
            SqlCommand cmd;
            string qry = "";
            ELCompany ObjEL = new ELCompany();
            SqlDataReader dr;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Company  WHERE ";

                if (Code != "")
                    qry = qry + " code =@Code ";
                else if (ID > 0)
                    qry = qry + " ID =@ID";
                else
                    qry = qry + " ID =@ID";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Code", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Code;
                cmd.Parameters.Add(param);

                foreach (SqlParameter Parameter in cmd.Parameters)
                {
                    if (Parameter.Value == null)
                    {
                        Parameter.Value = DBNull.Value;
                    }
                }

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    ObjEL.ID = Convert.ToInt32(dr["id"]);
                    ObjEL.Code = dr["Code"].ToString();
                    ObjEL.Name = dr["Name"].ToString();
                    ObjEL.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    ObjEL.Creator = Convert.ToInt32(dr["Creator"]);
                    ObjEL.Created = Convert.ToDateTime(dr["Created"]);

                }
                dr.Close();

                return ObjEL;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompany - FetchByID");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public static int Add(ELCompany objEL)
        {
            int retValue = 0;
            SqlCommand cmd;
            string qry = "";
            object value;
            try
            {
                conn.CreatConnection();

                qry = "";

                qry = "SELECT COUNT(ID) FROM Company WHERE ID =@ID ";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objEL.ID;
                cmd.Parameters.Add(param);

                foreach (SqlParameter Parameter in cmd.Parameters)
                {
                    if (Parameter.Value == null)
                    {
                        Parameter.Value = DBNull.Value;
                    }
                }

                value = cmd.ExecuteScalar();

                if (value != null && value.ToString() != "0")
                {
                    qry = "";
                    qry = "UPDATE Company SET Code=@Code, Name =@Name,CompanyID=@CompanyID,IsActive=@IsActive WHERE ID=@ID";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Name;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.IsActive;
                    cmd.Parameters.Add(param);

                    foreach (SqlParameter Parameter in cmd.Parameters)
                    {
                        if (Parameter.Value == null)
                        {
                            Parameter.Value = DBNull.Value;
                        }
                    }

                    retValue = cmd.ExecuteNonQuery();
                }
                else
                {
                    qry = "";

                    qry = "INSERT INTO Company (ID, CODE, NAME,CompanyID, CREATOR , CREATED, ISACTIVE) " +
                        " VALUES(@ID, @Code, @Name,@CompanyID, @Creator, @Created, @IsActive) ";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Name;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Creator", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Creator;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Created", SqlDbType.DateTime);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Created;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.IsActive;
                    cmd.Parameters.Add(param);

                    foreach (SqlParameter Parameter in cmd.Parameters)
                    {
                        if (Parameter.Value == null)
                        {
                            Parameter.Value = DBNull.Value;
                        }
                    }

                    retValue = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompany - Add");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
            return retValue;
        }

        public static int DeleteByID(int ID)
        {
            int retValue = 0;

            SqlCommand cmd;
            string qry = "";

            try
            {
                conn.CreatConnection();

                qry = "DELETE FROM Company WHERE ID = @ID";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ID;
                cmd.Parameters.Add(param);

                foreach (SqlParameter Parameter in cmd.Parameters)
                {
                    if (Parameter.Value == null)
                    {
                        Parameter.Value = DBNull.Value;
                    }
                }

                retValue = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompany - DeleteByID");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
            return retValue;
        }
    }
}
