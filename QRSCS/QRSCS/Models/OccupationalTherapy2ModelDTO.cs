using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Common.OT2;
using System.ComponentModel.DataAnnotations;
namespace QRSCS.Models
{
    public class OccupationalTherapy2ModelDTO
    {
        public OccupationalTherapy2Model occupationalTherapy2 { get; set; }
        public AttentionalProcessingOT2Model attentionalProcessing { get; set; }
        public AuditoryProcessingOT2Model auditoryProcessing { get; set; }
        public AvoidingOT2Model avoidingOT2 { get; set; }
        public BodyPositionProcessingOT2Model bodyPositionProcessing { get; set; }
        public ConductProcessingOT2Model conductProcessing { get; set; }
        public MovementProcessingOT2Model movementProcessing { get; set; }
        public OralSensoryProcessingOT2Model oralSensoryProcessing { get; set; }
        public RegistrationOT2Model registrationOT2 { get; set; }
        public SeekingOT2Model seekingOT2 { get; set; }
        public SensitivityOT2Model sensitivityOT2 { get; set; }
        public SocialEmotionalProcessingOT2Model socialEmotionalProcessing { get; set; }
        public TouchProcessingOT2Model touchProcessing { get; set; }
        public VisualProcessingOT2Model visualProcessing { get; set; }

    }
}