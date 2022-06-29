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

        public static ProgressCarreer CastToProgressCarreer(Curriculum curriculum)
        {
            return new ProgressCarreer
            {
                CurriculumCode = curriculum.Code,
                ApprovedSubjects = curriculum.Subjects.Select(t => t.Subject).ToList()
            };
        }

        public void RemoveFrom(ProgressCarreer progressCarreer)
        {
            //Firts remove the aproved subjects from the progressCarreer sended by paramns 
            var relatedDifference = this.Subjects.Select(t => t.Subject)
                .Except(progressCarreer.ApprovedSubjects, new SubjectComparer())
                .ToList();

            //var z = this.Subjects.Select(t=> t.RelatedSubjects)
            //    .Where(x => !progressCarreer.ApprovedSubjects.Any(x));

            var za = this.Subjects
                //.Except(z)
                .Where(t => t.RelatedSubjects.Any(x => !progressCarreer.ApprovedSubjects.Contains(x)));

            ////Then remove all the subjects who have correlatives which arent approved
            //var candidateSubjects = this.Subjects
            //    .Except(za)
            //    //.Where(t => t.RelatedSubjects.Any(x => !progressCarreer.ApprovedSubjects.Contains(x)))
            //    .Select(t => t.Subject)
            //    .ToList();

            var candidateSubjects = this.Subjects
                .Where(t => !za.Contains(t) || !t.RelatedSubjects.Any())
                .Select(t => t.Subject)
                .ToList();

            //TIENE QUE DEVOLVER A Y B


            //TBD...
            relatedDifference = relatedDifference.Where(t => candidateSubjects.Contains(t)).ToList();

            // Then remove all the aproved subject from the references of the original study plan 
            var relatedList = new List<Related>();
            foreach (var related in this.Subjects)
            {
                if (relatedDifference.Any(x => x.Code == related.Subject.Code))
                {
                    var r = new Related();
                    r.Subject = related.Subject;
                    r.RelatedSubjects = related.RelatedSubjects?.Where(y => !progressCarreer.ApprovedSubjects.Select(k => k.Code).Any(z => z == y.Code)).ToList();
                    relatedList.Add(r);
                }
            }

            this.Subjects = relatedList;
        }
    }
}
