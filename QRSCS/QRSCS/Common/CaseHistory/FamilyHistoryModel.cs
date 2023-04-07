using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace QRSCS.Common.CaseHistory
{
    public class FamilyHistoryModel
    {
        public int Family_History_ID { get; set; }
        public int CaseHistory_ID { get; set; }
        [Required(ErrorMessage = "Kindly enter User Father's Name")]
        public string Father_Name { get; set; }
        [Required(ErrorMessage = "Kindly enter User Father's Age")]
        public int Father_Age { get; set; }
        public string Father_Education { get; set; }
        public string Father_Profession { get; set; }
        public string Father_Financial_Status { get; set; }
        public string Father_General_Health { get; set; }
        public string Father_Blood_Group { get; set; }
        public string Year_of_Marriage { get; set; }
        public int Father_Age_at_the_time_of_Child_Birth { get; set; }
        public string Father_Paternal_Relationship { get; set; }
        public string Father_Family_System { get; set; }
        public string Mother_Name { get; set; }
        public int Mother_Age { get; set; }
        public string Mother_Education { get; set; }
        public string Mother_Profession { get; set; }
        public string Mother_Financial_Status { get; set; }
        public string Mother_General_Health { get; set; }
        public string Mother_Blood_Group { get; set; }
        public int Mother_Age_at_the_time_of_Child_Birth { get; set; }
        public string Mother_Paternal_Relationship { get; set; }
        public string Mother_Family_System { get; set; }
    }
}