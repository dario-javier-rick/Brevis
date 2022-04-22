namespace Brevis.Core.Test.Mocks
{
    using Brevis.Core.Model;
    using System.Collections.Generic;

    public static class CorrelativitiesMocks
    {
        public static Correlativities introduccionALaProgramacion = new Correlativities()
        {
            Subject = SubjectMocks.introduccionALaProgramacion,
            CorrelativeSubjects = new List<Subject>()
        };
        public static Correlativities ProgramacionI = new Correlativities()
        {
            Subject = SubjectMocks.ProgramacionI,
            CorrelativeSubjects = new List<Subject>() { SubjectMocks.introduccionALaProgramacion }
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
