using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Models
{
    public class AudioAssessmentDTO
    {
        public int GR_NO { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Father_Name { get; set; } = string.Empty;
        public string Disability { get; set; } = string.Empty;
        public string Test_Date { get; set; } = string.Empty;
        public bool IsPresent { get; set; } = false;
        public bool IsContent { get; set; } = false;


        //public string LeftEarAirUnmaskedFrequecy { get; set; } = string.Empty;
        //public string LeftEarAirUnmaskedHearingLevel { get; set; } = string.Empty;
        //public string LeftEarBoneMaskedFrequecy { get; set; } = string.Empty;
        //public string LeftEarBoneMaskedHearingLevel { get; set; } = string.Empty;
        //public string RightEarAirUnmaskedFrequecy { get; set; } = string.Empty;
        //public string RightEarAirUnmaskedHearingLevel { get; set; } = string.Empty;
        //public string RightEarBoneMaskedFrequecy { get; set; } = string.Empty;
        //public string RightEarBoneMaskedHearingLevel { get; set; } = string.Empty;
    }
}