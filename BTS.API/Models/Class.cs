using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTS.API.Models
{
    public class ClassApiModel
    {
        public int ClassScheduleID { get; set; }
        public ClassDescriptionApiModel ClassDescription { get; set; }
    }
}
