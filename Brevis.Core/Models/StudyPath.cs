namespace Brevis.Core.Models
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
        public ICollection<Subject> GetCriticalStudyPath(ProgressCarreer progressCarreer)
        {
            if (progressCarreer == null)
            {
                throw new ArgumentException();
            }

            var businessProcess = new CriticalPathBusinessProcess();
            return businessProcess.GetCriticalPath(progressCarreer);
        }
    }
}
