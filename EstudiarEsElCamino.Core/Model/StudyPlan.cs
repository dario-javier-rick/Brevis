namespace EstudiarEsElCamino.Core.Model
{
    using System.Linq;
    using System.Collections.Generic;

    public class StudyPlan
    {
        public ICollection<Correlativities> Correlativities;

        public StudyPlan(ICollection<Correlativities> correlativities)
        {
            this.Correlativities = correlativities;
        }

        public StudyPlan DifferenceWith(StudyPlan anotherStudyPlan) 
        {
            var correlativitiesDifference = anotherStudyPlan.Correlativities.Except(this.Correlativities, new CorrelativitiesComparer()).ToList();
            return new StudyPlan(correlativitiesDifference);
        }
    }
}
