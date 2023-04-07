using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace QRSCS.Manager
{
    public class LoginManager
    {
        public CreateUserModel checklogin(LoginModel logindata)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                var data = db.Users.Where(x => x.UserName == logindata.UserName && x.Password == logindata.Password).FirstOrDefault();
                CreateUserModel userdata = null;
                if (data != null)
                {
                    userdata = new CreateUserModel()
                    {
                        Full_Name = data.Full_Name,
                        User_ID = data.User_ID,
                        Picture = data.Picture,
                        UserName = data.UserName,
                        Password = data.Password,
                        IsActive = data.IsActive.Value,
                        Desigation_Role = data.Designation_Role,
                    };
                }
                
                return userdata;
            }
        }
    }
}