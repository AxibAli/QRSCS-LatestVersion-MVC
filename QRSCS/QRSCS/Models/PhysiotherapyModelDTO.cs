using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Common.PT;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Models
{
    public class PhysiotherapyModelDTO
    {
        public PhysiotherapyModel physiotherapyModel { get; set; }
        public HistoryPregnancyPTModel historyPregnancy { get; set; }
        public MedicalInformationPTModel medicalInformation { get; set; }
        public MilestonePTModel milestonePT { get; set; }
        public PhysicalAssessmentPTModel physicalAssessment { get; set; }
        public TestDonePTModel testDone { get; set; }
        public TreatmentPlanPTModel treatmentPlan { get; set; }

    }
}