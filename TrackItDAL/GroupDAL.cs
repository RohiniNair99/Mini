using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItDTO;


namespace TrackItDAL
{
    public class GroupDAL
    {
        SqlConnection sqlConobj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItConstr"].ToString());
        SqlCommand sqlCmdobj;



        public int AddGroup(GroupDTO GrupObj)
        {
            try
            {
                {
                    sqlCmdobj = new SqlCommand("[dbo].[uspAddParticipant]", sqlConobj);

                    sqlCmdobj.CommandType = CommandType.StoredProcedure;
                    sqlCmdobj.Parameters.AddWithValue("@PNAME", GrupObj.GroupName);
                    sqlCmdobj.Parameters.AddWithValue("@Noofparticipant", GrupObj.NoofParticipant);


               

                    sqlConobj.Open();

                    SqlParameter prmReturn = new SqlParameter();
                    prmReturn.ParameterName = "ReturnValue";
                    prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                    prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                    sqlCmdobj.Parameters.Add(prmReturn);


                    sqlCmdobj.ExecuteNonQuery();
                    int returnVal = Convert.ToInt32(prmReturn.Value);
                    return returnVal;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConobj.Close();
            }
        }

        public int UpdateParticipantGroupId(int groupId,int pid)
        {
            try
            {
                {
                    sqlCmdobj = new SqlCommand("dbo.uspUpdateParticipantGroupId", sqlConobj);
                    sqlCmdobj.CommandType = CommandType.StoredProcedure;
                    sqlCmdobj.Parameters.AddWithValue("@GroupId", groupId);
                    sqlCmdobj.Parameters.AddWithValue("@PartiId", pid);


                    sqlConobj.Open();

                    SqlParameter prmReturn = new SqlParameter();
                    prmReturn.ParameterName = "ReturnValue";
                    prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                    prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                    sqlCmdobj.Parameters.Add(prmReturn);

                    sqlCmdobj.ExecuteNonQuery();

                    int returnVal = Convert.ToInt32(prmReturn.Value);
                    return returnVal;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConobj.Close();
            }
        }

    }
}
