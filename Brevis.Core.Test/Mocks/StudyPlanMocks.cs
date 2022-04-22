namespace Brevis.Core.Test.Mocks
{
    using Brevis.Core.Models;
    using System.Collections.Generic;
    public static class StudyPlanMocks
    {
        public static StudyPlan EmptyStudyPlan()
        { return new StudyPlan(new List<Correlativities>() { }); }

        public static StudyPlan StudyPlanWithOneCorrelativitie()
        {
            return new StudyPlan(new List<Correlativities>()
            {
                CorrelativitiesMocks.IntroduccionALaProgramacion
            });
        }

        public static StudyPlan StudyPlanWithTwoCorrelativities()
        {
            return new StudyPlan(new List<Correlativities>()
            {
                CorrelativitiesMocks.IntroduccionALaProgramacion,
                CorrelativitiesMocks.ProgramacionI
            });
        }


        public static StudyPlan StudyPlanWithThreeCorrelativities()
        {
            return new StudyPlan(new List<Correlativities>()
            {
                CorrelativitiesMocks.IntroduccionALaProgramacion,
                CorrelativitiesMocks.ProgramacionI,
                CorrelativitiesMocks.ProgramacionII
            });
        }
    }
}
