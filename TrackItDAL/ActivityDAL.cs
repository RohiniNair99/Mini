using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItDTO;
using System.Configuration;

namespace TrackItDAL
{
    public class ActivityDAL
    {
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        TrackItconnect connect;

        public ActivityDAL()
        {
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["WebApiGroup2Entities"].ToString());
            connect = new TrackItconnect();
        }


        public int AddActivity(ActivityDTO actObj)
        {


            try
            {

                sqlCmd = new SqlCommand("uspAddActivity", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ActivityId", actObj.ActivityId);
                sqlCmd.Parameters.AddWithValue("@Activityname", actObj.ActivityName);
                sqlCmd.Parameters.AddWithValue("@StartDate", actObj.StartDate);
                sqlCmd.Parameters.AddWithValue("@EndDate", actObj.EndDate);
                sqlCmd.Parameters.AddWithValue("@GitSubmission", actObj.GitSubmission);
                sqlCmd.Parameters.AddWithValue("@CGId", actObj.CGId);
                sqlCmd.Parameters.AddWithValue("@FacultyId", actObj.FacultyId);




                sqlCon.Open();

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.ParameterName = "ReturnValue";
                prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                sqlCmd.Parameters.Add(prmReturn);

                sqlCmd.ExecuteNonQuery();

                int returnVal = Convert.ToInt32(prmReturn.Value);
                return returnVal;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }
        }


        public List<ActivityParticipantDTO> GetActivityParticipants(int facultyId, int activityId)
        {
            try
            {
                List<ActivityParticipantDTO> activityParticipants = new List<ActivityParticipantDTO>();
                var listFromDb = connect.Activities.Join(connect.ActivityPrticipantMaps, x => x.ActivityId, y => y.ActivityId, (x, y) => new { aId = x, apId = y }).Where(x => x.aId.FacultyId == facultyId && x.apId.ActivityId == activityId).Select(x => new { x.apId.PartiId, x.apId.ActivityStatus }).OrderBy(x => x.ActivityStatus).ToList();
                foreach (var item in listFromDb)
                {
                    activityParticipants.Add(new ActivityParticipantDTO
                    {
                        PartiId = item.PartiId,
                        ActivityStatus = item.ActivityStatus
                    });
                }
                return activityParticipants;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            public List<ActivityParticipantDTO> GetActivities(int participantId)
            {
                try
                {
                    List<ActivityParticipantDTO> listActivities = new List<ActivityParticipantDTO>();
                    var listFromDb = connect.ActivityPrticipantMaps.Where(x => x.PartiId == participantId).ToList();
                    foreach (var item in listFromDb)
                    {
                        listActivities.Add(new ActivityParticipantDTO
                        {

                            ActivityId = item.ActivityId,
                            ActivityStatus=item.ActivityStatus
                           
                        });
                        
                    }
                    return listActivities;
                }
                catch(Exception ex)
                {
                    throw ex;
                }

        }
    }
}
