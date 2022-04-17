namespace EstudiarEsElCamino.Core.Test.Mocks
{
    using EstudiarEsElCamino.Core.Model;
    using System.Collections.Generic;
    public static class StudyPlanMocks
    {
        public static StudyPlan EmptyStudyPlan()
        { return new StudyPlan(new List<Correlativities>() { }); }

        public static StudyPlan StudyPlanWithOneCorrelativitie()
        {
            return new StudyPlan(new List<Correlativities>()
            {
                CorrelativitiesMocks.introduccionALaProgramacion
            });
        }

        public static StudyPlan StudyPlanWithTwoCorrelativities()
        {
            return new StudyPlan(new List<Correlativities>()
            {
                CorrelativitiesMocks.introduccionALaProgramacion,
                CorrelativitiesMocks.ProgramacionI
            });
        }


        public static StudyPlan StudyPlanWithThreeCorrelativities()
        {
            return new StudyPlan(new List<Correlativities>()
            {
                CorrelativitiesMocks.introduccionALaProgramacion,
                CorrelativitiesMocks.ProgramacionI,
                CorrelativitiesMocks.ProgramacionII
            });
        }
    }
}
