using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Models
{
    public class SpeechTherapyAssessmentModel
    {
        public int Speech_Therapy_Assessment_ID { get; set; }

        public int GR_NO { get; set; }

        
        public string Speech_Test_Image { get; set; }
        public HttpPostedFileBase Speech_Test_Image_File { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Assessment { get; set; }

        public string Full_Name { get; set; }
        public int Marks { get; set; }

        public int Std_Class { get; set; }



    }
}