using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using QRSCS.Common.CaseHistory;

namespace QRSCS.Models
{
    public class CaseHistoryModelDTO
    {
        public FamilyHistoryModel FamilyHistory { get; set; }

        public BehavioralObservationModel BehavioralObservation { get; set; }

        public CaseHistoryModel CaseHistory { get; set; }

        public ConclusionModel Conclusion { get; set; }

        public DevelopmentHistoryModel DevelopmentHistory { get; set; }

        public EducationHistoryModel EducationHistory { get; set; }

        public MedicalHistoryModel MedicalHistory { get; set; }

        public ParticularsOfSiblingModel ParticularsOfSibling { get; set; }

        public PostNatalModel PostNatal { get; set; }

        public PsychoSocialFactorModel PsychoSocialFactor { get; set; }

        public RecommendationModel Recommendation { get; set; }

    }
}