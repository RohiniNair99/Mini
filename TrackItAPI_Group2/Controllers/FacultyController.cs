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
    public class FacultyController : ApiController
    {
        FacultyBL blObj;

        [HttpPost]
        [ActionName("AddFaculty")]
        public HttpResponseMessage AddFaculty(FacultyDTO obj)
        {
            try
            {
                if (obj.FacultyName != null && obj.FacultyEmailId != null)
                {
                    blObj = new FacultyBL();
                    int result = blObj.AddFaculty(obj);
                    if (result == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Faculty Inserted Successfully. \nReturn Value:" + result);
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else if (result == -1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("FacultyName already present.Try different FacultyName \nReturnValue:" + result);
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

        [HttpPost]
        [ActionName("GroupId")]
        public HttpResponseMessage UpdateGid(int pid,int gid)
        {
            try
            {
                if (pid != 0 && gid != 0)
                {
                    blObj = new FacultyBL();
                    int result = blObj.UpdateParticipantGid(pid, gid);
                    if (result == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent(" Inserted Successfully. \nReturn Value:" + result);
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else if (result == -1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Mapping already present.Try different Mapping\nReturnValue:" + result);
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
