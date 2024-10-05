﻿namespace Wombat.Common.Models
{
    public class LoggedAssessmentVM
    {
        public LoggedAssessmentVM()
        {
            OptionCriterionResponses = new List<OptionCriterionResponseVM>();
            TraineeId = "";
            AssessorId = "";
            EPAId = 0;
            Comment = "";
        }

        public int Id { get; set; }
        public string TraineeId { get; set; }
        public WombatUserVM? Trainee { get; set; }

        public string AssessorId { get; set; }
        public WombatUserVM? Assessor { get; set; }

        public int EPAId { get; set; }
        public EPAVM? EPA { get; set; }

        public List<OptionCriterionResponseVM> OptionCriterionResponses { get; set; }

        public string? Comment { get; set; }

        public DateTime AssessmentDate { get; set; }
    }
}
