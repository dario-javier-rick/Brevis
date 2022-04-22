namespace Brevis.Core.Test.Mocks
{
    using Brevis.Core.Model;
    using System.Collections.Generic;

    public static class CorrelativitiesMocks
    {
        public static Correlativities IntroduccionALaProgramacion = new Correlativities()
        {
            Subject = SubjectMocks.IntroduccionALaProgramacion,
            CorrelativeSubjects = new List<Subject>()
        };

        public static Correlativities ProgramacionI = new Correlativities()
        {
            Subject = SubjectMocks.ProgramacionI,
            CorrelativeSubjects = new List<Subject>() { SubjectMocks.IntroduccionALaProgramacion }
        };

        public static Correlativities ProgramacionII = new Correlativities()
        {
            Subject = SubjectMocks.ProgramacionII,
            CorrelativeSubjects = new List<Subject>() { SubjectMocks.ProgramacionI }
        };

        public static Correlativities ProgramacionIII = new Correlativities()
        {
            Subject = SubjectMocks.ProgramacionIII,
            CorrelativeSubjects = new List<Subject>() { SubjectMocks.ProgramacionII }
        };
    }
}
