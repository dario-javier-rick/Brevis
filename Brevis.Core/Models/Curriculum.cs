namespace Brevis.Core.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using System;

    public class Curriculum
    {
        public string Code { get; set; }
        public ICollection<Related> Subjects;

        public Curriculum(ICollection<Related> related)
        {
            this.Subjects = related;
        }



        public static Curriculum RemoveFrom(ProgressCarreer progressCarreer, Curriculum curriculum)
        {
            //Firts remove the aproved subjects from the progressCarreer sended by paramns 
            var relatedDifference = curriculum.Subjects.Select(t => t.Subject).ToList().Except(progressCarreer.ApprovedSubjects, new SubjectComparer()).ToList();

            // Then remove all the aproved subject from the references of the original study plan 
            var relatedList = new List<Related>();
            foreach (var related in curriculum.Subjects)
            {
                if (relatedDifference.Any(x => x.Code == related.Subject.Code)) 
                {
                    var r = new Related();
                    r.Subject = related.Subject;
                    r.RelatedSubjects = related.RelatedSubjects.Where(y => !progressCarreer.ApprovedSubjects.Select(k => k.Code).Any(z => z == y.Code)).ToList();
                    relatedList.Add(r);
                }
            }

            curriculum.Subjects = relatedList;

            return curriculum;
        }
    }
}
