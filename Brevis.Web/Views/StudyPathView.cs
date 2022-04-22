using Brevis.Core;
using Brevis.Core.Models;

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
