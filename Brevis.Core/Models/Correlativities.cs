namespace Brevis.Core.Models
{
    using System;
    using System.Collections.Generic;

    public class Correlativities
    {
        public Subject Subject;

        public ICollection<Subject> CorrelativeSubjects;
    }

    public class CorrelativitiesComparer : IEqualityComparer<Correlativities>
    {
        public bool Equals(Correlativities x, Correlativities y)
        {
            return new SubjectComparer().Equals(x.Subject, y.Subject);
        }

        public int GetHashCode(Correlativities obj)
        {
            return obj.Subject.Code.GetHashCode();
        }
    }

    public class SubjectComparer : IEqualityComparer<Subject>
    {
        public bool Equals(Subject x, Subject y)
        {
            if (string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Code, y.Code, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Subject obj)
        {
            return obj.Code.GetHashCode();
        }
    }
}