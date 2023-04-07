using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using QRSCS.Common.OT1;

namespace QRSCS.Models
{
    public class OccupationalTherapy1ModelDTO
    {
        public OccupationalTherapy1Model occupationalTherapy1 { get; set; }
        public OT1_Page1Model ot1_Page1 { get; set; }
        public OT1_Page2Model ot1_Page2 { get; set; }
        public OT1_Page3Model ot1_Page3 { get; set; }
    }
}