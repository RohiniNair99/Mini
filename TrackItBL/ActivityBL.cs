using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItDTO;
using TrackItDAL;

namespace TrackItBL
{
    public class ActivityBL
    {
        ActivityDAL dalObj;

        public ActivityBL()
        {
            dalObj = new ActivityDAL();

        }

        public int AddActivity(ActivityDTO aObj)
        {
            try
            {

                int result = dalObj.AddActivity(aObj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ActivityParticipantDTO> ActivityParticipantList(int facId, int activityId)
        {
            try
            {
                var activityList = dalObj.GetActivityParticipants(facId, activityId);
                return activityList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ActivityParticipantDTO> ActivityList(int participantId)
        {
            try
            {
                var activityList = dalObj.GetActivities(participantId);
                return activityList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
