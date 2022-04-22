using Brevis.Core;
using Brevis.Core.Model;

namespace Brevis.Web.Views
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
