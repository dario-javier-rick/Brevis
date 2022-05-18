namespace Brevis.Core.Models
{
    using System.Linq;
    using System.Collections.Generic;

    public class Curriculum
    {
        public string Code { get; set; }
        public ICollection<Related> Related;

        public Curriculum(ICollection<Related> correlativities)
        {
            this.Related = correlativities;
        }

        public void RemoveFrom(Curriculum anotherStudyPlan)
        {
            //Firts remove the aproved subjects from the studyPlan sended by paramns
            var relatedDifference = anotherStudyPlan.Related.Except(this.Related, new RelatedComparer()).ToList();
            // Then remove all the aproved subject from the references of the original study plan
            relatedDifference.ForEach(x => x.RelatedSubjects = x.RelatedSubjects.Except(this.Related.Select(z => z.Subject), new SubjectComparer()).ToList());
            //Finally update the current collection of correlativities with the remaining result.
            this.Related = relatedDifference;
        }
    }
}
