
using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;
using QRSCS.Models;

namespace QRSCS_Database
{
    namespace QRSCS.Manager
    {

        public class DashboardManager
        {
            private New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();
            public DashboardModel Cards_for_Admin(DashboardModel dm)
            {
                dm.total_users = db.Users.Count();
                dm.total_teachers = db.Users.Where(x => x.Designation_Role == 2).Count();
                dm.total_admins = db.Users.Where(x => x.Designation_Role == 1).Count();
                dm.total_students = db.New_Admission.Count();
                dm.total_IEP = db.IEPlans.Count();
                dm.total_teachers_percent = (float)Math.Round((float)dm.total_teachers / (float)dm.total_users *100, 2);
                dm.total_admin_percent = (float)Math.Round((float)dm.total_admins / (float)dm.total_users * 100, 2);
                var hi = db.New_Admission.Where(x => x.Disability == "H.I").Count();
                var vi = db.New_Admission.Where(x => x.Disability == "V.I").Count();
                var idd = db.New_Admission.Where(x => x.Disability == "I.D.D").Count();
                dm.CP_student = db.New_Admission.Where(x => x.Disability == "C.P").Count();
                dm.PH_student = db.New_Admission.Where(x => x.Disability == "P.H").Count();

                var deact = db.Users.Where(x => x.IsActive == false).Count();

                dm.total_histudents = hi;
                dm.total_vistudents = vi;
                dm.total_iddstudents = idd;
                dm.total_deactivated_users = deact;

                dm.total_deactivated_admins = db.Users.Where(x => x.Designation_Role == 1).Where(x => x.IsActive == false).Count();
                dm.total_deactivated_teachers = db.Users.Where(x => x.Designation_Role == 2).Where(x => x.IsActive == false).Count();
                dm.total_deactivated_teachers_percent = (float)Math.Round((float)dm.total_deactivated_teachers / (float)dm.total_teachers * 100, 2);
                dm.total_deactivated_admins_percent = (float)Math.Round((float)dm.total_deactivated_admins / (float)dm.total_admins * 100, 2);
                
                dm.total_iddstudents_percent =(float) Math.Round( (float)dm.total_iddstudents / (float)dm.total_students * 100,2);
                dm.total_histudents_percent = (float)Math.Round((float)dm.total_histudents / (float)dm.total_students * 100, 2);
                dm.total_vistudents_percent = (float)Math.Round((float)dm.total_vistudents / (float)dm.total_students * 100, 2);


                dm.class1 = db.New_Admission.Where(x => x.Class == 1).Count();
                dm.class2 = db.New_Admission.Where(x => x.Class == 2).Count();
                dm.class3 = db.New_Admission.Where(x => x.Class == 3).Count();
                dm.class4 = db.New_Admission.Where(x => x.Class == 4).Count();
                dm.class5 = db.New_Admission.Where(x => x.Class == 5).Count();
                dm.class6 = db.New_Admission.Where(x => x.Class == 6).Count();
                dm.class7 = db.New_Admission.Where(x => x.Class == 7).Count();
                dm.class8 = db.New_Admission.Where(x => x.Class == 8).Count();
                dm.class9 = db.New_Admission.Where(x => x.Class == 9).Count();
                dm.class10 = db.New_Admission.Where(x => x.Class == 10).Count();

                return dm;
            }
            public DashboardModel Cards_for_Teacher(DashboardModel dm,int user_id)
            {
               var result  = (from Users in db.Users
                              join Assign_Teacher in db.Assign_Teacher on Users.User_ID equals Assign_Teacher.User_ID
                              where Users.User_ID == user_id
                              select Assign_Teacher.Class).FirstOrDefault();

                if(result > 0 ) {

                    dm.Class_of_Teacher = result;
                dm.total_students = db.New_Admission.Where(x => x.Class== dm.Class_of_Teacher ).Count();
                dm.total_histudents_in_class = db.New_Admission.Where(x => x.Class == dm.Class_of_Teacher).Where(x => x.Disability == "H.I").Count();
                dm.total_vistudents_in_class = db.New_Admission.Where(x => x.Class == dm.Class_of_Teacher).Where(x => x.Disability == "V.I").Count();
                dm.total_iddstudents_in_class = db.New_Admission.Where(x => x.Class == dm.Class_of_Teacher).Where(x => x.Disability == "I.D.D").Count();
                dm.total_cpstudents_in_class = db.New_Admission.Where(x => x.Class == dm.Class_of_Teacher).Where(x => x.Disability == "C.P").Count();
                dm.total_phstudents_in_class = db.New_Admission.Where(x => x.Class == dm.Class_of_Teacher).Where(x => x.Disability == "P.H").Count();

                dm.total_iddstudents_percent_in_class = (float)Math.Round((float)dm.total_iddstudents_in_class / (float)dm.total_students * 100, 2);
                dm.total_histudents_percent_in_class = (float)Math.Round((float)dm.total_histudents_in_class / (float)dm.total_students * 100, 2);
                dm.total_vistudents_percent_in_class = (float)Math.Round((float)dm.total_vistudents_in_class / (float)dm.total_students * 100, 2);
                
                    return dm;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

