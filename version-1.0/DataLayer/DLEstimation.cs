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
    public class DLEstimation
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

                qry = " SELECT * FROM Estimation ";

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

        public static ELEstimation FetchByID(int ID = 0, string Code = "")
        {
            SqlCommand cmd;
            string qry = "";
            ELEstimation ObjEL = new ELEstimation();
            SqlDataReader dr;
            try
            {
                conn.CreatConnection();

                qry = "SELECT * FROM Estimation  WHERE ";

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
                    ObjEL.Site = dr["Site"].ToString();
                    ObjEL.QualityType = dr["QualityType"].ToString();
                    ObjEL.Units = Convert.ToInt32(dr["Units"]);
                    ObjEL.UnitType = dr["UnitType"].ToString();
                    ObjEL.RatePerUnit = Convert.ToInt32(dr["RatePerUnit"]);
                    ObjEL.TotalCost = Convert.ToInt32(dr["TotalCost"]);
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

        public static int Add(ELEstimation objEL)
        {
            int retValue = 0;
            SqlCommand cmd;
            string qry = "";
            object value;
            try
            {
                conn.CreatConnection();

                qry = "";

                qry = "SELECT COUNT(ID) FROM Estimation WHERE ID =@ID ";

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
                    qry = "UPDATE Estimation SET Code=@Code, Site =@Site ,QualityType=@QualityType,Units=@Units, "
                            + "UnitType=@UnitType,RatePerUnit=@RatePerUnit,TotalCost=@TotalCost,IsActive=@IsActive WHERE ID=@ID";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Site", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Site;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityType", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.QualityType;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Units", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Units;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitType", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.UnitType;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RatePerUnit", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.RatePerUnit;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalCost", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.TotalCost;
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

                    qry = "INSERT INTO Estimation  ([ID],[Code],[Site],[QualityType],[Units],[UnitType],[RatePerUnit],[TotalCost],[Creator],[Created],[IsActive]) " +
                        " VALUES(@ID, @Code, @Site, @QualityType, @Units, @UnitType,@RatePerUnit,@TotalCost,@Creator,Getdate(),@IsActive) ";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Site", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Site;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityType", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.QualityType;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Units", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.Units;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitType", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.UnitType;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RatePerUnit", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.RatePerUnit;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalCost", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objEL.TotalCost;
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

        public static int AddALL(Dictionary<int, ELEstimation> objDic)
        {
            //Dictionary<int, ELEstimation> objDic = new Dictionary<int, ELEstimation>();
            //ELEstimation objEL;
            int retValue = 0;
            SqlCommand cmd;
            string qry = "";
            SqlParameter param;

            try
            {
                conn.CreatConnection();
                foreach (var dicValue in objDic)
                {
                    qry = "";

                    qry = "INSERT INTO Estimation  ([ID],[Code],[Site],[QualityType],[Units],[UnitType],[RatePerUnit],[TotalCost],[Creator],[Created],[IsActive]) " +
                        " VALUES(@ID, @Code, @Site, @QualityType, @Units, @UnitType,@RatePerUnit,@TotalCost,@Creator,@Created,@IsActive) ";

                    cmd = new SqlCommand(qry, conn.con);

                    param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Code", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.Code;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Site", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.Site;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityType", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.QualityType;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Units", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.Units;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitType", SqlDbType.NVarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.UnitType;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RatePerUnit", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.RatePerUnit;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalCost", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.TotalCost;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Creator", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.Creator;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Created", SqlDbType.DateTime);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.Created;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isActive", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dicValue.Value.IsActive;
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

                qry = "DELETE FROM Estimation WHERE ID = @ID";

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
