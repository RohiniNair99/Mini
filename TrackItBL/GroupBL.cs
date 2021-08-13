using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItDAL;
using TrackItDTO;

namespace TrackItBL
{
    public class GroupBL
    {
        GroupDAL groupObj;

        public GroupBL()
        {
            groupObj = new GroupDAL();

        }

        public int AddGroup(GroupDTO grupObj)
        {
            try
            {

                int result = groupObj.AddGroup(grupObj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
