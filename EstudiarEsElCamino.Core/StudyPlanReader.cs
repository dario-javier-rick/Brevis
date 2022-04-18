namespace EstudiarEsElCamino.Core
{
    using EstudiarEsElCamino.Core.Model;
    using System.IO;

    public class StudyPlanReader
    {
        private string FilePath;
        public StudyPlan StudyPlanReaded { get; set; }

        public StudyPlanReader()
        {
            this.FilePath = buildPath();
            var jsonStringFromFile = File.ReadAllText(this.FilePath);
            this.StudyPlanReaded = Newtonsoft.Json.JsonConvert.DeserializeObject<StudyPlan>(jsonStringFromFile);
        }

        private string buildPath()
        {
            return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Resources.StudyPlanFolder, Resources.DefaultJson);
        }
    }
}
