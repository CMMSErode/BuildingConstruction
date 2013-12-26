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
    public class DLUnit
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

                qry = "SELECT ID FROM Unit WHERE CODE=@Code";

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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLUnit - FetchIDbyCode");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public int DeleteByID(int UnitID)
        {
            int retValue = 0;

            SqlCommand cmd;
            string qry = "";
            object value;

            try
            {
                conn.CreatConnection();

                qry = "DELETE FROM Unit WHERE ID = @ID";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = UnitID;
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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLUnit - DeleteByID");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
            return retValue;
        }

        public int Add(ELUnit objELUnit)
        {
            int retValue = 0;
            SqlCommand cmd;
            string qry = "";
            object value;
            try
            {
                conn.CreatConnection();

                qry = "";

                qry = "SELECT COUNT(ID) FROM Unit WHERE ID =@ID ";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objELUnit.ID;
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
                    qry = "UPDATE Unit SET Code=@Code, Name =@Name,IsActive=@IsActive WHERE ID=@ID";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.Name;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.IsActive;
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

                    qry = "INSERT INTO Unit (ID, CODE, NAME, CREATOR , CREATED, ISACTIVE) " +
                        " VALUES(@ID, @Code, @Name, @Creator, @Created, @IsActive) ";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.Name;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Creator", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.Creator;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Created", SqlDbType.DateTime);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.Created;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELUnit.IsActive;
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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLUnit - Add");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
            return retValue;
        }
        public DataView FetchUnits()
        {
            SqlCommand cmd;
            string qry = "";
            DataView dv;
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Unit";

                cmd = new SqlCommand(qry, conn.con);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "unit");

                dv = ds.Tables[0].DefaultView;

                return dv;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLUnit - FetchUnits");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        public ELUnit FetchUnitsByID(int ID)
        {
            SqlCommand cmd;
            string qry = "";
            ELUnit ObjELUnit = new ELUnit();
            SqlDataReader dr;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Unit WHERE ID =@ID";

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

                    ObjELUnit.ID = Convert.ToInt32(dr["id"]);
                    ObjELUnit.Code = dr["Code"].ToString();
                    ObjELUnit.Name = dr["Name"].ToString();
                    ObjELUnit.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    ObjELUnit.Creator = Convert.ToInt32(dr["Creator"]);
                    ObjELUnit.Created = Convert.ToDateTime(dr["Created"]);

                }
                dr.Close();

                return ObjELUnit;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLUnit - FetchUnitsByID");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

    }
}
