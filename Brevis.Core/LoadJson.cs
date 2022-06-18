using System;
using System.IO;


namespace Brevis.Core
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
