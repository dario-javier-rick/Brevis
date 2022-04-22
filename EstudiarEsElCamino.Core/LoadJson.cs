using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace EstudiarEsElCamino.Core
{
    public static class JsonFileReader
    {
        public static T Read<T>(string filePath)
        {
            string text = File.ReadAllText(filePath);
            //return JsonSerializer.Deserialize<T>(text);
            throw new NotImplementedException();
        }
    }
}
