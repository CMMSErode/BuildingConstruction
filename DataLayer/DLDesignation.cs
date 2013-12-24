using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UtilityLayer;
using EntityLayer;

namespace DataLayer
{
    public class DLDesignation
    {
        DLConnection conn = new DLConnection();

        public int FetchIDbyCode(string Code)
        {
            SqlCommand cmd;
            string qry = "";
            object value;
            int ID;
            try
            {
                conn.CreatConnection();

                qry = "SELECT ID FROM Designation WHERE CODE=@Code";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@Code", SqlDbType.NVarChar);
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

                value = cmd.ExecuteScalar();

                if (value != null && value.ToString() != "")
                {
                    ID = Convert.ToInt32(value.ToString());
                }
                else
                {
                    ID = 0;
                }

                return ID;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLDesignation - FetchIDbyCode");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        public int DeleteByID(int DesignationID)
        {
            int retValue = 0;

            SqlCommand cmd;
            string qry = "";
            object value;

            try
            {
                conn.CreatConnection();

                qry = "DELETE FROM Designation WHERE ID = @ID";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = DesignationID;
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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLDesignation - DeleteByID");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
            return retValue;
        }
        public int Add(ELDesignation objELDesignation)
        {
            int retValue = 0;
            SqlCommand cmd;
            string qry = "";
            object value;
            try
            {
                conn.CreatConnection();

                qry = "";

                qry = "SELECT COUNT(ID) FROM Designation WHERE ID =@ID ";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objELDesignation.ID;
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
                    qry = "UPDATE Designation SET Code=@Code, Name =@Name,IsActive=@IsActive WHERE ID=@ID";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.Name;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.IsActive;
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

                    qry = "INSERT INTO Designation (ID, CODE, NAME, CREATOR , CREATED, ISACTIVE) " +
                        " VALUES(@ID, @Code, @Name, @Creator, @Created, @IsActive) ";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.Name;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Creator", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.Creator;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Created", SqlDbType.DateTime);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.Created;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELDesignation.IsActive;
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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLDesignation - Add");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
            return retValue;
        }
        public DataView FetchDesginations()
        {
            SqlCommand cmd;
            string qry = "";
            DataView dv;
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Designation";

                cmd = new SqlCommand(qry, conn.con);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "designation");

                dv = ds.Tables[0].DefaultView;

                return dv;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLDesignation - FetchDesginations");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        public ELDesignation FetchDesignationsByID(int ID)
        {
            SqlCommand cmd;
            string qry = "";
            ELDesignation ObjELDesignation = new ELDesignation();
            SqlDataReader dr;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Designation WHERE ID =@ID";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@id", SqlDbType.Int);
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

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    ObjELDesignation.ID = Convert.ToInt32(dr["id"]);
                    ObjELDesignation.Code = dr["Code"].ToString();
                    ObjELDesignation.Name = dr["Name"].ToString();
                    ObjELDesignation.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    ObjELDesignation.Creator = Convert.ToInt32(dr["Creator"]);
                    ObjELDesignation.Created = Convert.ToDateTime(dr["Created"]);

                }
                dr.Close();

                return ObjELDesignation;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLDesignation - FetchDesignationsByID");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
    }
}
