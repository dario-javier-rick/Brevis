using EstudiarEsElCamino.Core;
using EstudiarEsElCamino.Core.Model;

namespace EstudiarEsElCamino.Web.Views
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
