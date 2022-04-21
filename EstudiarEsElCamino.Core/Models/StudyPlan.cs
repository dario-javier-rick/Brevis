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

        public void RemoveFrom(StudyPlan anotherStudyPlan)
        {
            //Firts remove the aproved subjects from the studyPlan sended by paramns
            var correlativitiesDifference = anotherStudyPlan.Correlativities.Except(this.Correlativities, new CorrelativitiesComparer()).ToList();
            // Then remove all the aproved subject from the references of the original study plan
            correlativitiesDifference.ForEach(x => x.CorrelativeSubjects = x.CorrelativeSubjects.Except(this.Correlativities.Select(z => z.Subject), new SubjectComparer()).ToList());
            //Finally update the current collection of correlativities with the remaining result.
            this.Correlativities = correlativitiesDifference;
        }
    }
}
