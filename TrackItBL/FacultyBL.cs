using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItDTO;
using TrackItDAL;

namespace TrackItBL
{
    public class FacultyBL
    {
        FacultyDAL factObj;
        GroupDAL gobj;

        public FacultyBL()
        {
            factObj = new FacultyDAL();

        }

        public int AddFaculty(FacultyDTO facObj)
        {
            try
            {

                int result = factObj.AddFaculty(facObj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int UpdateParticipantGid(int gid,int pid)
        {
            try
            {

                int result = gobj.UpdateParticipantGroupId(gid, pid);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
