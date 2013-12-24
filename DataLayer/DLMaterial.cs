using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace DataLayer
{
    public class DLMaterial
    {
        DLConnection conn = new DLConnection();

        public int Add(ELMaterial objELMaterial)
        {
            int retValue = 0;
            SqlCommand cmd;
            string qry = "";
            object value;
            try
            {
                conn.CreatConnection();

                qry = "";

                qry = "SELECT COUNT(ID) FROM Material WHERE ID = @ID ";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objELMaterial.ID;
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
                    qry = "UPDATE Material SET Code=@Code, Name =@Name,IsActive=@IsActive WHERE ID=@ID";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.Name;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.IsActive;
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

                    qry = "INSERT INTO Material (ID, CODE, NAME, CREATOR , CREATED, ISACTIVE) " +
                        " VALUES(@ID, @Code, @Name, @Creator, @Created, @IsActive) ";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.Name;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Creator", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.Creator;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Created", SqlDbType.DateTime);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.Created;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objELMaterial.IsActive;
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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLMaterial - Add");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
            return retValue;
        }
        public int DeleteByID(int MaterialID)
        {
            int retValue = 0;
           
            SqlCommand cmd;
            string qry = "";
            object value;
            
            try
            {
                conn.CreatConnection();

                qry = "DELETE FROM Material WHERE ID = @ID";

                cmd = new SqlCommand(qry, conn.con);

                SqlParameter param;

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = MaterialID;
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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLMaterial - DeleteByID");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }
            return retValue;
        }
        public int FetchIDbyCode(string Code)
        {
            SqlCommand cmd;
            string qry = "";
            object value;
            int ID;
            try
            {
               conn.CreatConnection();

                qry = "SELECT ID FROM Material WHERE CODE=@Code";

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
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLMaterial - FetchIDbyCode");
                return 0;
            }
            finally
            {
                conn.CloseConnection();
            }

            
        }

        public DataView FetchMaterials()
        {
            SqlCommand cmd;
            string qry = "";
            DataView dv;
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Material";

                cmd = new SqlCommand(qry, conn.con);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "material");

                dv = ds.Tables[0].DefaultView;

                return dv;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLMaterial - FetchMaterials");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }           
        }
        public ELMaterial FetchMaterialsByID(int ID)
        {
            SqlCommand cmd;
            string qry = "";
            ELMaterial ObjELMaterial = new ELMaterial();
            SqlDataReader dr;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Material WHERE ID =@ID";

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

                    ObjELMaterial.ID = Convert.ToInt32(dr["id"]);
                    ObjELMaterial.Code = dr["Code"].ToString();
                    ObjELMaterial.Name = dr["Name"].ToString();
                    ObjELMaterial.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    ObjELMaterial.Creator = Convert.ToInt32(dr["Creator"]);
                    ObjELMaterial.Created = Convert.ToDateTime(dr["Created"]);
                    
                }
                dr.Close();

                return ObjELMaterial;
            }
            catch (Exception ex)
            {
                UtilityLayer.Common.ErrorLog(DateTime.Now.ToString() + ex.Message + " " + ex.StackTrace + " " + "DLMaterial - FetchMaterialsByID");
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
    }

}
