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
    public class DLCompanyType
    {
        static DLConnection conn = new DLConnection();
        public static DataView FetchLikeBaseInfo(int CompanyID = 0, string CompanyCode = "", string like = "")
        {
            SqlCommand cmd;
            string qry = "";
            DataView dv;
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                conn.CreatConnection();

                qry = "select CT.* from Company C " +
                        " join CompanyType CT on C.ID=CT.CompanyID where ";
                if (like == "")
                {
                    if (CompanyCode != "")
                        qry = qry + " C.Code=@CompanyCode ";
                    else if (CompanyID > 0)
                        qry = qry + " C.ID=@CompanyID ";
                    else
                        qry = qry + " C.ID=@CompanyID ";
                }
                else
                {
                    qry = qry + " C.Code like '% @Code %' OR  C.ID like '% @ID %'";
                }

                cmd = new SqlCommand(qry, conn.con);
                SqlParameter param;

                param = new SqlParameter("@CompanyID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = CompanyID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = CompanyCode;
                cmd.Parameters.Add(param);

                foreach (SqlParameter Parameter in cmd.Parameters)
                {
                    if (Parameter.Value == null)
                    {
                        Parameter.Value = DBNull.Value;
                    }
                }

                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "CompanyTypes");

                dv = ds.Tables[0].DefaultView;

                return dv;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompanyType - FetchLikeBaseInfo");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public static ELCompanyType FetchByBaseInfo(int ID = 0, string Code = "")
        {
            SqlCommand cmd;
            string qry = "";
            ELCompanyType ObjEL = new ELCompanyType();
            SqlDataReader dr;
            try
            {
                conn.CreatConnection();

                qry = "select CT.* from Company C " +
                        " join CompanyType CT on C.ID=CT.CompanyID where ";

                if (Code != "")
                    qry = qry + " C.Code=@CompanyCode ";
                else if (ID > 0)
                    qry = qry + " C.ID=@CompanyID ";
                else
                    qry = qry + " C.ID=@CompanyID ";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Code", SqlDbType.VarChar);
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
                    ObjEL.CompanyID = Convert.ToInt32(dr["CompanyID"]);
                    ObjEL.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    ObjEL.Creator = Convert.ToInt32(dr["Creator"]);
                    ObjEL.Created = Convert.ToDateTime(dr["Created"]);

                }
                dr.Close();

                return ObjEL;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompanyType - FetchByBaseInfo");
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

                qry = "SELECT * FROM CompanyType  WHERE ";

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

                param = new SqlParameter("@Code", SqlDbType.VarChar);
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
                da.Fill(ds, "CompanyTypes");

                dv = ds.Tables[0].DefaultView;

                return dv;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompanyType - FetchLikeDatas");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

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

                qry = "SELECT * FROM CompanyType";

                cmd = new SqlCommand(qry, conn.con);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "CompanyTypes");

                dv = ds.Tables[0].DefaultView;

                return dv;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompanyType - FetchAll");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public static ELCompanyType FetchByID(int ID = 0, string Code = "")
        {
            SqlCommand cmd;
            string qry = "";
            ELCompanyType ObjEL = new ELCompanyType();
            SqlDataReader dr;
            try
            {
                conn.CreatConnection();

                qry = "SELECT CT.*,C.ID As CompanyID,C.Code As CompanyCode,C.Name As CompanyName FROM CompanyType CT " + 
                        " join Company C on CT.CompanyID=C.ID WHERE ";

                if (Code != "")
                    qry = qry + " CT.code =@Code ";
                else if (ID > 0)
                    qry = qry + " CT.ID =@ID";
                else
                    qry = qry + " CT.ID =@ID";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Code", SqlDbType.VarChar);
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
                    ObjEL.CompanyID = Convert.ToInt32(dr["CompanyID"]);
                    ObjEL.CompanyCode = dr["CompanyCode"].ToString();
                    ObjEL.CompanyName = dr["CompanyName"].ToString();
                    ObjEL.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    ObjEL.Creator = Convert.ToInt32(dr["Creator"]);
                    ObjEL.Created = Convert.ToDateTime(dr["Created"]);

                }
                dr.Close();

                return ObjEL;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompanyType - FetchByID");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public static int Add(ELCompanyType objEL)
        {
            int retValue = 0;
            SqlCommand cmd;
            string qry = "";
            object value;
            try
            {
                conn.CreatConnection();

                qry = "";

                qry = "SELECT COUNT(ID) FROM CompanyType WHERE ID =@ID ";

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
                    qry = "UPDATE CompanyType SET Code=@Code, Name =@Name,CompanyID=@CompanyID,IsActive=@IsActive WHERE ID=@ID";

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

                    param = new SqlParameter("@CompanyID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.CompanyID;
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

                    qry = "INSERT INTO CompanyType (ID, CODE, NAME,CompanyID, CREATOR , CREATED, ISACTIVE) " +
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

                    param = new SqlParameter("@CompanyID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.CompanyID;
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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompanyType - Add");
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

                qry = "DELETE FROM CompanyType WHERE ID = @ID";

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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLCompanyType - DeleteByID");
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