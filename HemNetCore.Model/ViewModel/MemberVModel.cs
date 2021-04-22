using System;
using System.Collections.Generic;
using System.Text;

namespace HemNetCore.Model.ViewModel
{
    public class MemberVModel
    {
       public Guid MemberID { get; set; }
       public string LoginName { get; set; }

        public string UserName { get; set; }

        public DateTime? VIPExpirationTime { get; set; }

        public  string PartnerName { get; set; }

        public int Sex { get; set; }

        public DateTime? LoginLastTime { get; set; }
    }
}
