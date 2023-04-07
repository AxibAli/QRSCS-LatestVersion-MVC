using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class NewAdmissionManager
    {
        int grno = 0;
        public int AddStudent(NewAdmissionModel grn)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                New_Admission stdtbl = new New_Admission();
                stdtbl.GR_NO = grn.Gr_No;
                stdtbl.Student_First_Name = grn.Student_First_Name;
                stdtbl.Date_of_Addmission = grn.Date_of_Admission;
                stdtbl.Student_Last_Name = grn.Student_Last_Name;
                stdtbl.Class = grn.Class;
                stdtbl.Gender = grn.Gender;
                stdtbl.Dob = grn.Dob;
                stdtbl.Place_of_Birth = grn.Place_of_Birth;
                stdtbl.Religion = grn.Religion;
                stdtbl.Name_Last_School_Attended = grn.Name_Last_School_Attended;
                stdtbl.Hobbies = grn.Hobbies;
                stdtbl.Father_Name = grn.Father_Name;
                stdtbl.Education = grn.Education;
                stdtbl.NIC = grn.NIC;
                stdtbl.Relationship_with_Student = grn.Relation_with_Student;
                stdtbl.Monthly_Income = grn.Monthy_Income;
                stdtbl.Occupation = grn.Occupation;
                stdtbl.Category = grn.Category;
                stdtbl.Address = grn.Address;
                stdtbl.City = grn.City;
                stdtbl.State = grn.State;
                stdtbl.Zip_Code = grn.Zip_Code;
                stdtbl.Contact = grn.Contact;
                stdtbl.Phone_Residence = grn.Phone_Residence;
                stdtbl.Phone_Office = grn.Phone_Office;
                stdtbl.Disability = grn.Disability;
                stdtbl.Presenting_Complain = grn.Presenting_Complain;
                stdtbl.User_ID = grn.User_ID;
                db.New_Admission.Add(stdtbl);
                db.SaveChanges();

                grno = stdtbl.GR_NO;
            }
            return grno;
        }

        internal DashboardModel GetStudent(object gR_NO)
        {
            throw new NotImplementedException();
        }

        public NewAdmissionModel GetStudent(int GR_NO)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.New_Admission.Where(x => x.GR_NO == GR_NO).FirstOrDefault();
                NewAdmissionModel User = null;
                if (request != null)
                {
                    User = new NewAdmissionModel()
                    {
                        Gr_No = request.GR_NO,
                        Student_First_Name = request.Student_First_Name,
                        Student_Last_Name = request.Student_Last_Name,
                        Class = request.Class,
                        Gender = request.Gender,
                        Dob = request.Dob,
                        Place_of_Birth = request.Place_of_Birth,
                        Religion = request.Religion,
                        Name_Last_School_Attended = request.Name_Last_School_Attended,
                        Hobbies = request.Hobbies,
                        Father_Name = request.Father_Name,
                        Education = request.Education,
                        NIC = request.NIC,
                        Relation_with_Student = request.Relationship_with_Student,
                        Monthy_Income = request.Monthly_Income,
                        Occupation = request.Occupation,
                        Category = request.Category,
                        Address = request.Address,
                        City = request.City,
                        State = request.State,
                        Zip_Code = request.Zip_Code,
                        Contact = request.Contact,
                        Phone_Residence = request.Phone_Residence,
                        Phone_Office = request.Phone_Office,
                        Disability = request.Disability,
                        Presenting_Complain = request.Presenting_Complain,
                        User_ID = request.User_ID


                    };
                    return User;
                }

                else
                {
                    return User;
                }
            }
        }
        public List<NewAdmissionModel> selectAllAdmission()
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.New_Admission.ToList();
                List<NewAdmissionModel> List = request.Select(x => new NewAdmissionModel
                {
                    Gr_No = x.GR_NO,
                    Student_First_Name = x.Student_First_Name,
                    Student_Last_Name = x.Student_Last_Name,
                    Father_Name = x.Father_Name,
                    Gender = x.Gender,
                    Disability = x.Disability,
                    IsActive = x.IsActive.Value 
                }).ToList();
                return List;
            }
        }


        public List<NewAdmissionModel> selectAllAdmission(int classe)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.New_Admission.Where(x => x.Class == classe);
                List<NewAdmissionModel> List = request.Select(x => new NewAdmissionModel
                {
                    Gr_No = x.GR_NO,
                    Student_First_Name = x.Student_First_Name,
                    Student_Last_Name = x.Student_Last_Name,
                    Father_Name = x.Father_Name,
                    Gender = x.Gender,
                    Disability = x.Disability,
                   
                }).ToList();
                return List;
            }
        }


        public List<NewAdmissionModel> selectHI()
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.New_Admission.Where(x => x.Disability == "H.I");
                List<NewAdmissionModel> List = request.Select(x => new NewAdmissionModel
                {
                    Gr_No = x.GR_NO,
                    Student_First_Name = x.Student_First_Name,
                    Student_Last_Name = x.Student_Last_Name,
                    Father_Name = x.Father_Name,
                    Gender = x.Gender,
                    Contact = x.Contact
                }).ToList();
                return List;
            }
        }

        public List<NewAdmissionModel> selectVI()
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.New_Admission.Where(x => x.Disability == "V.I");
                List<NewAdmissionModel> List = request.Select(x => new NewAdmissionModel
                {
                    Gr_No = x.GR_NO,
                    Student_First_Name = x.Student_First_Name,
                    Student_Last_Name = x.Student_Last_Name,
                    Father_Name = x.Father_Name,
                    Gender = x.Gender,
                    Contact = x.Contact
                }).ToList();
                return List;
            }
        }


        public List<NewAdmissionModel> selectIDD()
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.New_Admission.Where(x => x.Disability == "I.D.D");
                List<NewAdmissionModel> List = request.Select(x => new NewAdmissionModel
                {
                    Gr_No = x.GR_NO,
                    Student_First_Name = x.Student_First_Name,
                    Student_Last_Name = x.Student_Last_Name,
                    Father_Name = x.Father_Name,
                    Gender = x.Gender,
                    Contact = x.Contact
                }).ToList();
                return List;
            }
        }



        public bool UpdateStudent(NewAdmissionModel grno)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var Data = db.New_Admission.Where(x => x.GR_NO == grno.Gr_No).FirstOrDefault();
                if (Data != null)
                {


                    Data.Student_First_Name = grno.Student_First_Name;
                    Data.Student_Last_Name = grno.Student_Last_Name;
                    Data.Class = grno.Class;
                    Data.Gender = grno.Gender;
                    Data.Dob = grno.Dob;
                    Data.Place_of_Birth = grno.Place_of_Birth;
                    Data.Religion = grno.Religion;
                    Data.Name_Last_School_Attended = grno.Name_Last_School_Attended;
                    Data.Hobbies = grno.Hobbies;
                    Data.Father_Name = grno.Father_Name;
                    Data.Education = grno.Education;
                    Data.NIC = grno.NIC;
                    Data.Relationship_with_Student = grno.Relation_with_Student;
                    Data.Monthly_Income = grno.Monthy_Income;
                    Data.Occupation = grno.Occupation;
                    Data.Category = grno.Category;
                    Data.Address = grno.Address;
                    Data.City = grno.City;
                    Data.State = grno.State;
                    Data.Zip_Code = grno.Zip_Code;
                    Data.Contact = grno.Contact;
                    Data.Phone_Residence = grno.Phone_Residence;
                    Data.Phone_Office = grno.Phone_Office;
                    Data.Disability = grno.Disability;
                    Data.Presenting_Complain = grno.Presenting_Complain;
                    Data.Updated_By = grno.Updated_By;
                    Data.Update_Date = grno.Update_Date;

                    db.Entry(Data).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}