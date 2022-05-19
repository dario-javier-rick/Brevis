namespace Brevis.Core.Test.Mocks
{
    using Brevis.Core.Models;
    using System.Collections.Generic;

    public static class RelatedMocks
    {
        /*public static Related IntroduccionALaProgramacion = new Related()
        {
            Subject = SubjectMocks.IntroduccionALaProgramacion,
            RelatedSubjects = new List<Subject>()
        };
        */
        public static Related A = new Related()
        {
            Subject = SubjectMocks.A,
            RelatedSubjects = new List<Subject>() { SubjectMocks.C }
        };

        public static Related B = new Related()
        {
            Subject = SubjectMocks.B,
//            RelatedSubjects = new List<Subject>() { SubjectMocks.ProgramacionI }
        };

        public static Related C = new Related()
        {
            Subject = SubjectMocks.C,
//            RelatedSubjects = new List<Subject>() { SubjectMocks.B }
        };
    }
}
