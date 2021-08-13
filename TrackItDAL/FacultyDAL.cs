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
    public class FacultyDAL
    {
        SqlConnection sqlConobj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItConstr"].ToString());
        SqlCommand sqlCmdobj;



        public int AddFaculty(FacultyDTO facultyobj)
        {



            try
            {
                {
                    sqlCmdobj = new SqlCommand("[dbo].[uspAddFaculty]", sqlConobj);

                    sqlCmdobj.CommandType = CommandType.StoredProcedure;
                    sqlCmdobj.Parameters.AddWithValue("@FacultyName", facultyobj.FacultyName);
                    sqlCmdobj.Parameters.AddWithValue("@FEMAIL", facultyobj.FacultyEmailId);

                    SqlParameter prmOutputId = new SqlParameter();
                    prmOutputId.ParameterName = "@ID";
                    prmOutputId.Direction = ParameterDirection.Output;
                    prmOutputId.SqlDbType = SqlDbType.Int;
                    sqlCmdobj.Parameters.Add(prmOutputId);

                    sqlConobj.Open();

                    SqlParameter prmReturn = new SqlParameter();
                    prmReturn.ParameterName = "ReturnValue";
                    prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                    prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                    sqlCmdobj.Parameters.Add(prmReturn);

                    sqlCmdobj.ExecuteNonQuery();
                    int OutId = Convert.ToInt32(prmOutputId.Value);
                    return OutId;

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

        public int UpdateParticipantGroupId(GroupParticipantDTO GrupObj)
        {
            try
            {
                {
                    sqlCmdobj = new SqlCommand("dbo.uspUpdateParticipantGroupId", sqlConobj);
                    sqlCmdobj.CommandType = CommandType.StoredProcedure;
                    sqlCmdobj.Parameters.AddWithValue("@GroupId", GrupObj.GroupId);
                    sqlCmdobj.Parameters.AddWithValue("@PartiId", GrupObj.PartiId);


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
