using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QRSCS.Models
{
    public class CreateUserModel
    {

        public int User_ID { get; set; }

        [Required(ErrorMessage = "Kindly Write a User's Full Name?")]
        public string Full_Name { get; set; }

        [Required(ErrorMessage = "Kindly Write a User's Father Name?")]
        public string Father_Name { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "Enter a valid NIC of 14 Digits")]
        [MinLength(14, ErrorMessage = "Enter a valid NIC of 14 Digits")]
        public string NIC { get; set; }

        [Required(ErrorMessage = "Kindly Select a Gender?")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Kindly Enter a Date of Birth?")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Enter a valid Contact Format: 03##-#######")]
        [MinLength(11, ErrorMessage = "Enter a valid contact Format: 03##-#######")]
        public string Contact_Number { get; set; }
        public string Rank { get; set; }

        [Required(ErrorMessage = "Kindly Select a Role?")]
        public int Desigation_Role { get; set; }

        [Required(ErrorMessage = "Kindly Enter a Address?")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Kindly Enter a City?")]
        public string City { get; set; }

        [Required(ErrorMessage = "Kindly Enter a State?")]
        public string State { get; set; }

        [Required(ErrorMessage = "Kindly Enter a User Name?")]
        public string UserName { get; set; }

         



        //[Required]
        //[MinLength(8, ErrorMessage = "Password Should Be Minimum Of 8 Character")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Picture { get; set; }

        public string Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Creation_Date { get; set; }
        public string Updated_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Update_Date { get; set; }
        public bool IsActive { get; set; } = true;
        public LoginModel logininfo { get; set; }

        public HttpPostedFileBase Imageofuser { get; set; }

        public SelectList RolesList { get; set; }

    }
}