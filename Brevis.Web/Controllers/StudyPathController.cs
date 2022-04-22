using Brevis.Core;
using Brevis.Core.Model;
using Brevis.Web.Views;
using System.Collections.Generic;

namespace Brevis.Web.Controllers
{
    public class StudyPathController : Observer
    {
        protected StudyPath model;
        protected StudyPathView view;

        public StudyPathController(StudyPathView view)
        {
            this.view = view;
            model = view.GetModel();
            model.AttachObserver(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json">JSON with the subjects, correlativities and subject status</param>
        /// <returns></returns>
        public ICollection<Subject> GetCriticalStudyPath(string json)
        {
            return model.GetCriticalStudyPath(json);
        }
    }
}
