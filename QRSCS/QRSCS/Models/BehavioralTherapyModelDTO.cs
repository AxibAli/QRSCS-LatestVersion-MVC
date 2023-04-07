using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Common.BT;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Models
{
    public class BehavioralTherapyModelDTO
    {
        public BehavioralTherapyModel BehavioralTherapy { get; set; }
        public ClassroomObservationBTModel classroomObservationBT { get; set; }
        public Week1BTModel Week1BT { get; set; }
        public Week2BTModel Week2BT { get; set; }
        public Week3BTModel Week3BT { get; set; }
        public Week4BTModel Week4BT { get; set; }


    }
}