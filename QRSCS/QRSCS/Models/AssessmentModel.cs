using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Models
{
    public class AssessmentModel
    {
        public string LeftEarAirUnmaskedFrequecy { get; set; }
        public string LeftEarAirUnmaskedHearingLevel { get; set; }
        public string LeftEarBoneMaskedFrequecy { get; set; }
        public string LeftEarBoneMaskedHearingLevel { get; set; }
        public string RightEarAirUnmaskedFrequecy { get; set; }
        public string RightEarAirUnmaskedHearingLevel { get; set; }
        public string RightEarBoneMaskedFrequecy { get; set; }
        public string RightEarBoneMaskedHearingLevel { get; set; }
    }
}