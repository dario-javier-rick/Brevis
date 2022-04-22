namespace Brevis.Core.Model
{
    using System;
    using System.Collections.Generic; 

    public class StudyPath
    {
        IList<Observer> observers;

        public StudyPath()
        {
            observers = new List<Observer>();
        }

        public void AttachObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void DeattachObserver(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }

        /// <summary>
        /// Business logic
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public ICollection<Subject> GetCriticalStudyPath(string json)
        {
            if (json == "{}")
            {
                throw new ArgumentException();
            }
            var Runner = new Runner();
            Runner.ruuun();
            return null;//TODO: Temporary 
        }
    }
}
