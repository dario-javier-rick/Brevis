namespace Brevis.Core
{
    using Brevis.Core.Models;
    using System.IO;

    public class StudyPlanReader
    {
        public string FilePath;
        public Curriculum StudyPlanReaded { get; set; }

        public StudyPlanReader()
        {
            setFilePath();
            var jsonStringFromFile = File.ReadAllText(this.FilePath);
            this.StudyPlanReaded = Newtonsoft.Json.JsonConvert.DeserializeObject<Curriculum>(jsonStringFromFile);
        }

        private void setFilePath()
        {
            this.FilePath = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                Resources.StudyPlanFolder,
                "Plan0.json" //TODO: Fix this ASAP
                );
        }
    }
}
