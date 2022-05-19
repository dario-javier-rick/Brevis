namespace Brevis.Core.Test.Mocks
{
    using Brevis.Core.Models;
    using System.Collections.Generic;
    public static class CurriculumMocks
    {
        public static Curriculum EmptyCurriculum()
        { return new Curriculum(new List<Related>() { }); }

        public static Curriculum CurriculumWithOneCorrelativitie()
        {
            return new Curriculum(new List<Related>()
            {
                RelatedMocks.C
            });
        }
    }
}
