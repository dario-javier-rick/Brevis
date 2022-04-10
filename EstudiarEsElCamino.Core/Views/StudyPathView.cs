using EstudiarEsElCamino.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiarEsElCamino.Core.Views
{
    public class StudyPathView : Observer
    {
        StudyPath model;

        public StudyPathView(StudyPath model)
        {
            this.model = model;
        }

        public StudyPath GetModel()
        {
            return model;
        }
    }
}
