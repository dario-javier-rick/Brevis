using EstudiarEsElCamino.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiarEsElCamino.Core.Model
{
    public class StudyPlan
    {
        IEnumerable<Correlativities> correlativities;

        public StudyPlan(IEnumerable<Correlativities> correlativities)
        {
            this.correlativities = correlativities;
        }

    }
}
