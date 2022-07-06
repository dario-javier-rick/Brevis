using System;

namespace Brevis.Core.Models
{
    public class Subject
    {
        public string Code;
        public string Name;

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Subject other = (Subject)obj;
            return this.Code == other.Code
                && this.Name == other.Name;
        }
    }
}