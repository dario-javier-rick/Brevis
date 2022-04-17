namespace EstudiarEsElCamino.Core
{
    using EstudiarEsElCamino.Core.Model;
    using System.Collections.Generic;

    //TODO: pending to rename/relocate this class 
    public class Runner
    {
        public void ruuun()
        {
            var HardcodedStudyPlan = new StudyPlan(new List<Correlativities>()
            {
                new Correlativities {
                    Subject = new Subject { Name = "Introduccion: a la Programacion", Code= "00" },
                    CorrelativeSubjects = new List<Subject>()
                }
                //,
                // new Correlativities {
                //    Subject = new Subject { Name = "Programacion I", Code= "01" },
                //    CorrelativeSubjects = new List<Subject>() { new Subject { Name = "Introduccion: a la Programacion", Code= "00" } }
                //}
            }
            );

            this.ruuun(HardcodedStudyPlan);
        }

        public void ruuun(StudyPlan inputStudyPlan)
        {
            var defaultStudyPlan = new StudyPlanReader().ReadStudyPlanFromJson();
            var result = compareStudyPlans(inputStudyPlan, defaultStudyPlan);
        }


        private StudyPlan compareStudyPlans(StudyPlan inputStudyPlan, StudyPlan carreerStudyPlan)
        {
            return inputStudyPlan.DifferenceWith(carreerStudyPlan);
        }
    }
}
