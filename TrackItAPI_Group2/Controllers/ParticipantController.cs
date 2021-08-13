using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackItBL;
using TrackItDTO;

namespace TrackItAPI_Group2.Controllers
{
    public class ParticipantController : ApiController
    {
        [HttpGet]
        [ActionName("ViewActivity")]
        public HttpResponseMessage GetStatus(int participantId)
        {
            ActivityBL blObj;
            try
            {
                if (participantId != 0)
                {
                    blObj = new ActivityBL();
                    List<ActivityParticipantDTO> listOfActivities = blObj.ActivityList(participantId);

                    List<string> displayComplete = new List<string>();
                    foreach (var item in listOfActivities)
                    {
                        displayComplete.Add("ActivityId: " + item.ActivityId + ",Status: " + item.ActivityStatus);
                    }


                    if (listOfActivities != null)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent(JsonConvert.SerializeObject(displayComplete));
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                        response.Content = new StringContent(JsonConvert.SerializeObject("No Activities Available"));
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Please input ParticipantId"));
                    return response;
                }

            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject("Something went wrong"));
                return response;
            }
        }
    }
}
