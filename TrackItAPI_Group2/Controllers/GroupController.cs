using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackItDTO;
using TrackItBL;

namespace TrackItAPI_Group2.Controllers
{
    public class GroupController : ApiController
    {
        GroupBL blObj;

        [HttpPost]
        [ActionName("AddGroup")]
        public HttpResponseMessage AddGroup(GroupDTO obj)
        {
            try
            {
                if (obj.GroupName != null && obj.NoofParticipant != 0 && obj.GroupId != null)
                {
                    blObj = new GroupBL();
                    int result = blObj.AddGroup(obj);
                    if (result == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Group Inserted Successfully. \nReturn Value:" + result);
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else if (result == -1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("GroupName already present.Try different ParticipantName \nReturnValue:" + result);
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
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject("Something went wrong"));
                return response;
            }
        }

    }
}
