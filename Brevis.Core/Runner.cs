namespace Brevis.Core
{
    using Brevis.Core.Models;
    using System;
    using System.Collections.Generic;

    //TODO: pending to rename/relocate this class 
    public class Runner
    {
        public void ruuun()
        {
            var HardcodedRelated = new Curriculum(new List<Related>()
            {
                new Related {
                    Subject = new Subject { Name = "C", Code= "03" },
                    RelatedSubjects = new List<Subject>()
                }
                //,
                // new Related {
                //    Subject = new Subject { Name = "Programacion I", Code= "01" },
                //    RelatedSubjects = new List<Subject>() { new Subject { Name = "Introduccion: a la Programacion", Code= "00" } }
                //}
            }
            );

            this.ruuun(HardcodedRelated);
        }

        public void ruuun(Curriculum inputRelated)
        {
            var defaultStudyPlan = new StudyPlanReader().StudyPlanReaded;
            inputRelated.RemoveFrom(defaultStudyPlan);
            //TopologicalSort.Sort(inputStRelated, x => x.RelatedSubjects);
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
