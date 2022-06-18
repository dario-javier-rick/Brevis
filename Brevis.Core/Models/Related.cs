namespace Brevis.Core.Models
{
    using System;
    using System.Collections.Generic;

    public class Related
    {
        public Subject Subject;

        public ICollection<Subject> RelatedSubjects;
    }

    public class SubjectComparer : IEqualityComparer<Subject>
    {
        public bool Equals(Subject x, Subject y)
        {
            if (string.Equals(x.Code, y.Code, StringComparison.OrdinalIgnoreCase))
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