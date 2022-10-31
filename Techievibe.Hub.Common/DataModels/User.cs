using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techievibe.Hub.Common.CoreModels;

namespace Techievibe.Hub.Common.DataModels
{
    public class User : PersonDto
    {
        public int USR_ID { get; set; }
        public string USR_UNAME { get; set; }
        public string USR_PWD { get; set; }
        public string USR_EMAIL { get; set; }
        public string USR_SGNUP_TYPE { get; set; }
        public bool USR_ADMN_FLG { get; set; }
        public bool USR_ACT_FLG { get; set; }
        public DateTime CRT_DT { get; set; }
        public DateTime? UPD_DT { get; set; }
        public User CRT_USR_ID { get; set; }
        public User UPD_USR_ID { get; set; }
    }
}
