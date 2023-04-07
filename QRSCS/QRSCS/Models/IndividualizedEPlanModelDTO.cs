using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Common.IEP;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Models
{
    public class IndividualizedEPlanModelDTO
    {
        public IEPlanModel iEPlanModel { get; set; }
        public DevelopmentTeamIEPModel developmentTeam { get; set; }
        public MeetingInformationIEPModel meetingInformation { get; set; }
        public IEP_Page3Model iEP_Page3 { get; set; }
        public PresentLevelIEPModel presentLevel { get; set; }
        public SpecialInstructionalIEPModel specialInstructional { get; set; }
        public SupplementaryAidsIEPModel supplementaryAids { get; set; }


    }
}