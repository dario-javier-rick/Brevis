using EstudiarEsElCamino.Core.Model;
using EstudiarEsElCamino.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiarEsElCamino.Core.Controllers
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
        public IEnumerable<Model.Subject> GetCriticalStudyPath(string json)
        {
            return model.GetCriticalStudyPath(json);
        }
    }
}
