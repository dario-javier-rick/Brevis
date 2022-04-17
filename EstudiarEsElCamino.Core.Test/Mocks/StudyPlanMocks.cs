namespace EstudiarEsElCamino.Core.Test.Mocks
{
    using EstudiarEsElCamino.Core.Model;
    using System.Collections.Generic;
    public static class StudyPlanMocks
    {
        public static StudyPlan EmptyStudyPlan = new StudyPlan(new List<Correlativities>() { });

        public static StudyPlan StudyPlanWithOneCorrelativitie = new StudyPlan(new List<Correlativities>()
        {
            CorrelativitiesMocks.introduccionALaProgramacion
        });

        public static StudyPlan StudyPlanWithTwoCorrelativities = new StudyPlan(new List<Correlativities>()
        {
            CorrelativitiesMocks.introduccionALaProgramacion,
            CorrelativitiesMocks.ProgramacionI
        });


        public static StudyPlan StudyPlanWithThreeCorrelativities = new StudyPlan(new List<Correlativities>()
        {
            CorrelativitiesMocks.introduccionALaProgramacion,
            CorrelativitiesMocks.ProgramacionI,
            CorrelativitiesMocks.ProgramacionII
        });
    }
}
