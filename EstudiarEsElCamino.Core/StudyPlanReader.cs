namespace EstudiarEsElCamino.Core
{
    using EstudiarEsElCamino.Core.Model;
    using System.Collections.Generic;
    using System.IO;
    public class StudyPlanReader
    {
        public StudyPlanReader()
        {
        }
        public StudyPlan ReadStudyPlanFromJson()
        {
            var path = string.Concat(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Resources.StudyPathDefault);
            var jsonStringFromFile = File.ReadAllText(path);
            var correlativities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Correlativities>>(jsonStringFromFile);
            return new StudyPlan(correlativities);
        }
    }
}
