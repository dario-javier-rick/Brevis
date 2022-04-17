namespace EstudiarEsElCamino.Core.Model
{
    using System.Collections.Generic;
    
    public class StudyPlan
    {

        public IEnumerable<Correlativities> Correlativities;

        public StudyPlan(IEnumerable<Correlativities> correlativities)
        {
            this.Correlativities = correlativities;
        }
    }
}
