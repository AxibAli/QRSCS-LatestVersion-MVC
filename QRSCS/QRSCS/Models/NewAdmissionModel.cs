using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Models
{
    public class NewAdmissionModel
    {

        public int Gr_No { get; set; }

        [Required(ErrorMessage = "Kindly Select Date of Admission")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Admission { get; set; }

        [Required(ErrorMessage = "Kindly Write a Student First Name?")]
        public string Student_First_Name { get; set; }

        [Required(ErrorMessage = "Kindly Write a Student Last Name?")]
        public string Student_Last_Name { get; set; }

        [Required(ErrorMessage = "Kindly Select a Class")]
        public int Class { get; set; }

        [Required(ErrorMessage = "Kindly Select a Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Kindly Select a Date of Birth")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Kindly Write a Place of Birth")]
        public string Place_of_Birth { get; set; }

        [Required(ErrorMessage = "Kindly Write a Religion")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Kindly Write a Name of Last School Attended")]
        public string Name_Last_School_Attended { get; set; }

        [Required(ErrorMessage = "Kindly Write a Hobbie")]
        public string Hobbies { get; set; }

        [Required(ErrorMessage = "Kindly Write a Father Name")]
        public string Father_Name { get; set; }

        [Required(ErrorMessage = "Kindly Enter a Education")]
        public string Education { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Enter a valid NIC of 14 Digits")]
        [MinLength(15, ErrorMessage = "Enter a valid NIC of 14 Digits")]
        public string NIC { get; set; }

        [Required(ErrorMessage = "Kindly Write a Relation with Student")]
        public string Relation_with_Student { get; set; }


        [Required(ErrorMessage = "Kindly Write a Monthly Income")]
        public string Monthy_Income { get; set; }

        [Required(ErrorMessage = "Kindly Write a Occupation")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Kindly Select a Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Kindly Enter a Complete Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Kindly Enter a City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Kindly Enter a State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Kindly Enter a Zip Code")]
        public string Zip_Code { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "Enter a valid Contact Format: 03##-#######")]
        [MinLength(12, ErrorMessage = "Enter a valid contact Format: 03##-#######")]
        public string Contact { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "Enter a valid Contact Format: 03##-#######")]
        [MinLength(12, ErrorMessage = "Enter a valid contact Format: 03##-#######")]
        public string Phone_Residence { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "Enter a valid Contact Format: 03##-#######")]
        [MinLength(12, ErrorMessage = "Enter a valid contact Format: 03##-#######")]
        public string Phone_Office { get; set; }

        [Required(ErrorMessage = "Kindly Select a Disability")]
        public string Disability { get; set; }

        [Required(ErrorMessage = "Kindly Write a Presenting Complain")]
        public string Presenting_Complain { get; set; }

        public int User_ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Update_Date { get; set; }

        public string Updated_By { get; set; }


        public int total_users { get; internal set; }
        public int total_students { get; internal set; }
        public int total_teachers { get; internal set; }

        public int Role { get; set; }
        public bool IsActive { get; set; } = true;
        public LoginModel logininfo { get; set; }


    }
}