﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wombat.Application.Contracts;
using Wombat.Data;

namespace Wombat.Application.Repositories
{
    public class LoggedAssessmentRepository : GenericRepository<LoggedAssessment>, ILoggedAssessmentRepository
    {
        private readonly UserManager<WombatUser> userManager;
        private readonly IEPARepository EPARepository;
        private readonly IOptionCriterionResponseRepository optionCriterionResponse;

        public LoggedAssessmentRepository( ApplicationDbContext context,
                                           UserManager<WombatUser> userManager,
                                           IEPARepository EPA,
                                           IOptionCriterionResponseRepository optionCriterionResponse) : base(context)
        {
            this.userManager=userManager;
            this.EPARepository=EPA;
            this.optionCriterionResponse=optionCriterionResponse;
        }

        public override async Task<LoggedAssessment?> GetAsync(int? id)
        {
            var assessment = await base.GetAsync(id);

            if (assessment != null)
            {
                assessment.Trainee = await userManager.FindByIdAsync(assessment.TraineeId);
                assessment.Assessor = await userManager.FindByIdAsync(assessment.AssessorId);
                assessment.EPA = await EPARepository.GetAsync(assessment.EPAId);

                assessment.OptionCriterionResponses = await optionCriterionResponse.GetByAssessmentIdAsync(assessment.Id);
            }

            return assessment;
        }

        public override async Task<List<LoggedAssessment>?> GetAllAsync()
        {
            var assessments = await base.GetAllAsync();

            if( assessments != null )
            {
                foreach( var assessment in assessments )
                {
                    assessment.Trainee = await userManager.FindByIdAsync(assessment.TraineeId);
                    assessment.Assessor = await userManager.FindByIdAsync(assessment.AssessorId);
                    assessment.EPA = await EPARepository.GetAsync(assessment.EPAId);
                }
            }
            return assessments;
        }

        public async Task<List<LoggedAssessment>?> GetAssessmntsbyTraineeAsync(string id)
        {
            var assessments = await context.LoggedAssessments
                .Where(x => x.TraineeId == id)
                .ToListAsync();

            if (assessments != null)
            {
                foreach (var assessment in assessments)
                {
                    assessment.Trainee = await userManager.FindByIdAsync(assessment.TraineeId);
                    assessment.Assessor = await userManager.FindByIdAsync(assessment.AssessorId);
                    assessment.EPA = await EPARepository.GetAsync(assessment.EPAId);
                }
            }
            return assessments;
        }

        public async Task<List<LoggedAssessment>?> GetAssessmntsbyAssessorAsync(string id)
        {
            var assessments = await context.LoggedAssessments
                .Where(x => x.AssessorId == id)
                .ToListAsync();

            if (assessments != null)
            {
                foreach (var assessment in assessments)
                {
                    assessment.Trainee = await userManager.FindByIdAsync(assessment.TraineeId);
                    assessment.Assessor = await userManager.FindByIdAsync(assessment.AssessorId);
                    assessment.EPA = await EPARepository.GetAsync(assessment.EPAId);
                }
            }
            return assessments;
        }
    }
}
