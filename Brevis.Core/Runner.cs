namespace Brevis.Core
{
    using Brevis.Core.Model;
    using System;
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
            var defaultStudyPlan = new StudyPlanReader().StudyPlanReaded;
            inputStudyPlan.RemoveFrom(defaultStudyPlan); 
            //TopologicalSort.Sort(inputStCorrelativities, x => x.CorrelativeSubjects);
        }
    }

    public static class TopologicalSort 
    {
        public static IList<T> Sort<T>(this ICollection<T> source, Func<T, ICollection<T>> getDependencies)
        {
            var sorted = new List<T>();
            var visited = new Dictionary<T, bool>();

            foreach (var item in source)
            {
                Visit(item, getDependencies, sorted, visited);
            }

            return sorted;
        }

        public static void Visit<T>(T item, Func<T, IEnumerable<T>> getDependencies,
                           List<T> sorted, Dictionary<T, bool> visited)
        {
            bool inProcess;
            var alreadyVisited = visited.TryGetValue(item, out inProcess);

            if (alreadyVisited)
            {
                if (inProcess)
                {
                    throw new ArgumentException("Cyclic dependency found.");
                }
            }
            else
            {
                visited[item] = true;

                var dependencies = getDependencies(item);
                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        Visit(dependency, getDependencies, sorted, visited);
                    }
                }

                visited[item] = false;
                sorted.Add(item);
            }
        }

    }
}
