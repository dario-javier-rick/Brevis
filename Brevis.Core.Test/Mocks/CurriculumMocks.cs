namespace Brevis.Core.Test.Mocks
{
    using Brevis.Core.Models;
    using System.Collections.Generic;
    public static class CurriculumMocks
    {
        public static Curriculum EmptyCurriculum()
        { return new Curriculum(new List<Correlativities>() { }); }

        public static Curriculum CurriculumWithOneCorrelativitie()
        {
            return new Curriculum(new List<Correlativities>()
            {
                CorrelativitiesMocks.IntroduccionALaProgramacion
            });
        }

        public static Curriculum CurriculumWithTwoCorrelativities()
        {
            return new Curriculum(new List<Correlativities>()
            {
                CorrelativitiesMocks.IntroduccionALaProgramacion,
                CorrelativitiesMocks.ProgramacionI
            });
        }


        public static Curriculum CurriculumWithThreeCorrelativities()
        {
            return new Curriculum(new List<Correlativities>()
            {
                CorrelativitiesMocks.IntroduccionALaProgramacion,
                CorrelativitiesMocks.ProgramacionI,
                CorrelativitiesMocks.ProgramacionII
            });
        }
    }
}
