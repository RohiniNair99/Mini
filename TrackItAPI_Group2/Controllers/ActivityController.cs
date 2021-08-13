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
    public class ActivityController : ApiController
    {
        ActivityBL blObj;

        [HttpPost]
        [ActionName("AddAct")]
        public HttpResponseMessage AddActivity(ActivityDTO act)
        {
            try
            {
                if (act.ActivityName != null && act.StartDate != null && act.GitSubmission != null && act.CGId != 0 && act.FacultyId != 0)
                {
                    blObj = new ActivityBL();
                    int result = blObj.AddActivity(act);
                    if (result == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Activity Inserted Successfully. \nReturn Value:" + result);
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else if (result == -1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("ActivityName already present.Try different ActivityName \nReturnValue:" + result);
                        return response;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Return Value: " + result.ToString());
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    int result = -3;
                    response.Content = new StringContent("Please input all values \nReturn Value: " + result);
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

        [HttpGet]
        [ActionName("GetStatusList")]
        public HttpResponseMessage GetStatus(int facultyId, int activityId)
        {
            try
            {
                if (facultyId != 0 && activityId != 0)
                {
                    blObj = new ActivityBL();
                    List<ActivityParticipantDTO> listOfParticipants = blObj.ActivityParticipantList(facultyId, activityId);

                    List<string> displayComplete = new List<string>();
                    foreach (var item in listOfParticipants)
                    {
                        displayComplete.Add("PId:" + item.PartiId + ",Status: " + item.ActivityStatus);
                    }


                    if (listOfParticipants != null)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent(JsonConvert.SerializeObject(displayComplete));
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                        response.Content = new StringContent(JsonConvert.SerializeObject("No Students Available"));
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent(JsonConvert.SerializeObject("Please input facultyId and ActivityId"));
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
