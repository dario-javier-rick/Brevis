namespace EstudiarEsElCamino.Core.Model
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
            if (string.Equals(x.Subject.Name, y.Subject.Name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Subject.Code, y.Subject.Code, StringComparison.OrdinalIgnoreCase)) 
            {
                return true;
            } 
            return false;
        }

        public int GetHashCode(Correlativities obj)
        {
            return obj.Subject.Code.GetHashCode();
        }
    }
}