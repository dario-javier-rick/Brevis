using Brevis.Core;
using Brevis.Core.Model;
using Brevis.Core.Models;
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
        /// <param name="progressCarreer">Actual progress carreer</param>
        /// <returns></returns>
        public IEnumerable<Subject> GetCriticalStudyPath(ProgressCarreer progressCarreer)
        {
            return model.GetCriticalStudyPath(progressCarreer);
        }
    }
}
