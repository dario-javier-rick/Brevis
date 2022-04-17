namespace EstudiarEsElCamino.Core.Model
{
    using System.Linq;
    using System.Collections.Generic;

    public class StudyPlan
    {

        public IEnumerable<Correlativities> Correlativities;

        public StudyPlan(IEnumerable<Correlativities> correlativities)
        {
            this.Correlativities = correlativities;
        }

        public StudyPlan DifferenceWith(StudyPlan fromCompare) 
        {
            var correlativitiesIntersection = fromCompare.Correlativities.Except(this.Correlativities, new CorrelativitiesComparer());
            return new StudyPlan(correlativitiesIntersection);
        }
    }
}
