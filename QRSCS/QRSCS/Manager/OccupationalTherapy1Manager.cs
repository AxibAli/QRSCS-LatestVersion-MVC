using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class OccupationalTherapy1Manager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        int OT1_ID = 0;

        //Occupational Therapy 1
        public int AddOccupationalTherapy1(OccupationalTherapy1ModelDTO grno)
        {
            OccupationalTherapy1 table = new OccupationalTherapy1();
            table.GR_NO = grno.occupationalTherapy1.GR_NO;
            table.Date_of_Assessment = grno.occupationalTherapy1.Date_of_Assessment;
            db.OccupationalTherapy1.Add(table);
            OT1_ID = table.OT1_ID;

            OT1_Page1 table2 = new OT1_Page1();
            table2.OT1_ID = grno.occupationalTherapy1.OT1_ID;
            table2.Alertness = grno.ot1_Page1.Alertness;
            table2.Tone = grno.ot1_Page1.Tone;
            table2.Reflexes = grno.ot1_Page1.Reflexes;
            table2.Startle = grno.ot1_Page1.Startle;
            table2.ATNR = grno.ot1_Page1.ATNR;
            table2.Gallant = grno.ot1_Page1.Gallant;
            table2.Landau = grno.ot1_Page1.Landau;
            table2.Grasp = grno.ot1_Page1.Grasp;
            table2.Placing = grno.ot1_Page1.Placing;
            table2.Parachute = grno.ot1_Page1.Parachute;
            db.OT1_Page1.Add(table2);


            OT1_Page2 table3 = new OT1_Page2();
            table3.OT1_ID = grno.occupationalTherapy1.OT1_ID;
            table3.Remark_3_Months = grno.ot1_Page2.Remark_3_Months;
            table3.Remark_6_Months = grno.ot1_Page2.Remark_6_Months;
            table3.Remark_7_Months = grno.ot1_Page2.Remark_7_Months;
            table3.Remark_6_To_7_Months = grno.ot1_Page2.Remark_6_To_7_Months;
            table3.Remark_8_To_10_Months = grno.ot1_Page2.Remark_8_To_10_Months;
            table3.Remark_10_To_11_Months_Crawl = grno.ot1_Page2.Remark_10_To_11_Months_Crawl;
            table3.Remark_9_Months = grno.ot1_Page2.Remark_9_Months;
            table3.Remark_10_To_11_Months_Stands = grno.ot1_Page2.Remark_10_To_11_Months_Stands;
            table3.Remark_12_Months_Walks = grno.ot1_Page2.Remark_12_Months_Walks;
            table3.Remark_13_Months_Walks = grno.ot1_Page2.Remark_13_Months_Walks;
            table3.Remark_12_Months_Says = grno.ot1_Page2.Remark_12_Months_Says;
            table3.Remark_15_To_18_Months_Joints = grno.ot1_Page2.Remark_15_To_18_Months_Joints;
            table3.Remark_13_Months_Feeds = grno.ot1_Page2.Remark_13_Months_Feeds;
            table3.Remark_15_To_18_Months_Climb_Stairs = grno.ot1_Page2.Remark_15_To_18_Months_Climb_Stairs;
            table3.Remark_2_To_3_Years = grno.ot1_Page2.Remark_2_To_3_Years;
            table3.Remark_3_To_4_Years = grno.ot1_Page2.Remark_3_To_4_Years;
            db.OT1_Page2.Add(table3);


            OT1_Page3 table4 = new OT1_Page3();
            table4.OT1_ID = grno.occupationalTherapy1.OT1_ID;
            table4.Reach = grno.ot1_Page3.Reach;
            table4.Prehension = grno.ot1_Page3.Prehension;
            table4.Carry = grno.ot1_Page3.Carry;
            table4.Release = grno.ot1_Page3.Release;
            table4.Isolated = grno.ot1_Page3.Isolated;
            table4.Opposition = grno.ot1_Page3.Opposition;
            table4.TiptoTip = grno.ot1_Page3.TiptoTip;
            table4.Finger = grno.ot1_Page3.Finger;
            table4.Pre_writing = grno.ot1_Page3.Pre_writing;
            table4.Cognition = grno.ot1_Page3.Cognition;
            table4.Auditory = grno.ot1_Page3.Auditory;
            table4.Visual = grno.ot1_Page3.Visual;
            table4.Taste_Smell = grno.ot1_Page3.Taste_Smell;
            table4.Vestibular = grno.ot1_Page3.Vestibular;
            table4.Praxis = grno.ot1_Page3.Praxis;
            table4.Stereignosis = grno.ot1_Page3.Stereignosis;
            table4.Communication = grno.ot1_Page3.Communication;
            table4.Behaviour = grno.ot1_Page3.Behaviour;
            table4.Sleep = grno.ot1_Page3.Sleep;
            table4.Activities = grno.ot1_Page3.Activities;
            db.OT1_Page3.Add(table4);



            db.SaveChanges();
            OT1_ID = table.OT1_ID;
            return OT1_ID;

    }   }
}