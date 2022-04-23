namespace Brevis.Core
{
    using Brevis.Core.Models;
    using System.IO;

    public class StudyPlanReader
    {
        public string FilePath;
        public StudyPlan StudyPlanReaded { get; set; }

        public StudyPlanReader()
        {
            setFilePath();
            var jsonStringFromFile = File.ReadAllText(this.FilePath);
            this.StudyPlanReaded = Newtonsoft.Json.JsonConvert.DeserializeObject<StudyPlan>(jsonStringFromFile);
        }

        private void setFilePath()
        {
            this.FilePath = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                Resources.StudyPlanFolder,
                Resources.DefaultJson);
        }
    }
}
