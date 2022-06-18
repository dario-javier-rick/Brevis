namespace Brevis.Core
{
    using Brevis.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //TODO: pending to rename/relocate this class 
    public class CriticalPathBusinessProcess
    {
        public ICollection<Subject> GetCriticalPath(ProgressCarreer progressCarreer)
        {
            //Paso 1. Obtener el plan de estudios correspondiente.
            var defaultStudyPlan = new StudyPlanReader().StudyPlanReaded;

            //Paso 2. En base al plan de estudio y las materias aprobadas, calcular camino
            return this.GetCriticalPath(defaultStudyPlan, progressCarreer);
        }

        private ICollection<Subject> GetCriticalPath(Curriculum inputRelated, ProgressCarreer progressCarreer)
        {
            var result = Curriculum.RemoveFrom(progressCarreer, inputRelated);
            //TopologicalSort.Sort(inputStRelated, x => x.RelatedSubjects);

            return result.Subjects.Select(t => t.Subject).ToList();
        }
    }
      
}
