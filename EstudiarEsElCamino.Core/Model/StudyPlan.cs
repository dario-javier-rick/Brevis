namespace EstudiarEsElCamino.Core.Model
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.IO;

    public class StudyPlan
    {

        public IEnumerable<Correlativities> Correlativities;

        public StudyPlan(IEnumerable<Correlativities> correlativities)
        {
            this.Correlativities = correlativities;
        }

        public StudyPlan ReadStudyPlanFromJson(string path) 
        {
            var jsonStringFromFile = File.ReadAllText(path);
            var studyPlanFromJson = Newtonsoft.Json.JsonConvert.DeserializeObject<StudyPlan>(jsonStringFromFile);
            return studyPlanFromJson;
        }
    }
}
