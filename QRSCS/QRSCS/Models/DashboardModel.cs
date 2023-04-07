using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Models
{
    public class DashboardModel
    {
        public string List { get; set; }
        public int total_users { get; set; }
        public int total_deactivated_users { get; set; }
        public int total_students { get; set; }
        public int total_teachers { get; set; }
        public  float total_teachers_percent { get; set; }

        public float total_admin_percent { get; set; }

        public float total_deactivated_teachers { get; set; }

        public float total_deactivated_admins { get; set; }

        public float total_deactivated_teachers_percent { get; set; }

        public float total_deactivated_admins_percent { get; set; }
        public int total_histudents { get; set; }

        public float total_histudents_percent { get; set; }
        public int total_vistudents { get; set; }

        public float total_vistudents_percent { get; set; }

        public int total_iddstudents { get; set; }

        public float total_iddstudents_percent { get; set; }
        public int total_IEP { get; set; }

        public int User_ID { get; set; }
        public int total_admins { get; set; }

        public int  PH_student { get; set; }
        public int CP_student { get; set; }

        public int class1 { get; set; }
        public int class2 { get; set; }
        public int class3 { get; set; }
        public int class4 { get; set; }
        public int class5 { get; set; }
        public int class6 { get; set; }
        public int class7 { get; set; }
        public int class8 { get; set; }
        public int class9 { get; set; }
        public int class10 { get; set; }


        public int Class_of_Teacher { get; set; }
        public int total_histudents_in_class { get; set; }
        public int total_vistudents_in_class { get; set; }
        public int total_iddstudents_in_class { get; set; }
        public float total_iddstudents_percent_in_class { get; set; }
        public float total_vistudents_percent_in_class { get; set; }
        public float total_histudents_percent_in_class { get; set; }
        public int total_phstudents_in_class { get; set; }
        public int total_cpstudents_in_class { get; set; }

    }
}