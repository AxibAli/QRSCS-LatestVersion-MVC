using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class CreateUserManager : GeneralConnectionManager
    {
        int userid = 0;
        public int AddUser(CreateUserModel uid)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                User tbluser = new User();
                tbluser.Full_Name = uid.Full_Name;
                tbluser.Father_Name = uid.Father_Name;
                tbluser.NIC = uid.NIC;
                tbluser.Gender = uid.Gender;
                tbluser.DOB = uid.DOB;
                tbluser.Contact_Number = uid.Contact_Number;
                tbluser.Rank = uid.Rank;
                tbluser.Designation_Role = uid.Desigation_Role;
                tbluser.Address = uid.Address;
                tbluser.City = uid.City;
                tbluser.State = uid.State;
                tbluser.UserName = uid.UserName;
                tbluser.Password = uid.Password;
                tbluser.Picture = uid.Picture;
                tbluser.Created_By = uid.Created_By;
                tbluser.Creation_Date = uid.Creation_Date;
                tbluser.IsActive = true;
                 
                db.Users.Add(tbluser);
                db.SaveChanges();

                userid = tbluser.User_ID;
            }
            return userid;
        }

        public bool UpdateUserStatus(bool Status, int userId)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                try
                {
                    var result = db.Users.FirstOrDefault(x => x.User_ID == userId);
                    result.IsActive = Status;
                    db.Entry(result).State = EntityState.Modified;
                    var check = db.SaveChanges();
                    if (check > 0) return true;
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
        public bool UpdateStudentStatus(bool Status, int userId)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                try
                {
                    var result = db.New_Admission.FirstOrDefault(x => x.GR_NO == userId);
                    result.IsActive = Status;
                    db.Entry(result).State = EntityState.Modified;
                    var check = db.SaveChanges();
                    if (check > 0) return true;
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
        public List<CreateUserModel> selectUser()
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.Users.ToList();
                List<CreateUserModel> List = request.Select(x => new CreateUserModel
                {
                    User_ID = x.User_ID,
                    Picture = x.Picture,
                    Full_Name = x.Full_Name,
                    Father_Name = x.Father_Name,
                    NIC = x.NIC,
                    Gender = x.Gender,
                    DOB = x.DOB,
                    Contact_Number = x.Contact_Number,
                    Rank = x.Rank,
                    Desigation_Role = x.Designation_Role,
                    Address = x.Address,
                    City = x.City,
                    State = x.State,
                    UserName = x.UserName,
                    Password = x.Password,
                    IsActive = x.IsActive.Value
                }).ToList();
                return List;
            }
        }
        public List<CreateUserModel> selectTeacher()
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.Users.ToList();
                List<CreateUserModel> List = request.Select(x => new CreateUserModel
                {
                    User_ID = x.User_ID,
                    Picture = x.Picture,
                    Full_Name = x.Full_Name,
                    Father_Name = x.Father_Name,
                    NIC = x.NIC,
                    Gender = x.Gender,
                    DOB = x.DOB,
                    Contact_Number = x.Contact_Number,
                    Rank = x.Rank,
                    Desigation_Role = x.Designation_Role,
                    Address = x.Address,
                    City = x.City,
                    State = x.State,
                    UserName = x.UserName,
                    Password = x.Password,
                    IsActive = x.IsActive.Value
                }).Where(x=>x.Desigation_Role==2).ToList();
                return List;
            }
        }
        public CreateUserModel GetUser(int uid)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var request = db.Users.Where(x => x.User_ID == uid).FirstOrDefault();
                CreateUserModel User = null;
                if (request != null)
                {
                    User = new CreateUserModel()
                    {
                        User_ID = request.User_ID,
                        Picture = request.Picture,
                        Full_Name = request.Full_Name,
                        Father_Name = request.Father_Name,
                        NIC = request.NIC,
                        Gender = request.Gender,
                        DOB = request.DOB,
                        Contact_Number = request.Contact_Number,
                        Rank = request.Rank,
                        Desigation_Role = request.Designation_Role,
                        Address = request.Address,
                        City = request.City,
                        State = request.State,
                        UserName = request.UserName,
                        Password = request.Password,
                        IsActive = request.IsActive.Value
                    };
                    return User;
                }

                else
                {
                    return User;
                }
            }
        }

        public bool UpdateUser(CreateUserModel uid)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var Data = db.Users.Where(x => x.User_ID == uid.User_ID).FirstOrDefault();
                if (Data != null)
                {
                    Data.User_ID = uid.User_ID;
                    Data.Picture = uid.Picture;
                    Data.Full_Name = uid.Full_Name;
                    Data.Father_Name = uid.Father_Name;
                    Data.NIC = uid.NIC;
                    Data.Gender = uid.Gender;
                    Data.DOB = uid.DOB;
                    Data.Contact_Number = uid.Contact_Number;
                    Data.Rank = uid.Rank;
                    Data.Designation_Role = uid.Desigation_Role;
                    Data.Address = uid.Address;
                    Data.City = uid.City;
                    Data.State = uid.State;
                    Data.UserName = uid.UserName;
                    Data.Password = uid.Password;
                    Data.Updated_By = uid.Updated_By;
                    Data.Update_Date = uid.Update_Date;
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