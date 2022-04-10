using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiarEsElCamino.Core.Model
{
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
        public IEnumerable<Subject> GetCriticalStudyPath(string json)
        {
            if (json == "{}")
            {
                throw new ArgumentException();
            }

            throw new NotImplementedException();
        }
    }
}
