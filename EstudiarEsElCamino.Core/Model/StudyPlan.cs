namespace EstudiarEsElCamino.Core.Model
{
    using System.Collections.Generic;
    
    public class StudyPlan
    {

        IEnumerable<Correlativities> correlativities;

        public StudyPlan(IEnumerable<Correlativities> correlativities)
        {
            this.correlativities = correlativities;
        }

    }
}
