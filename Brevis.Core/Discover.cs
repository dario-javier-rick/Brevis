using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Brevis.Core
{
    public class Discover
    {
        public Discover()
        {
        }

        public Dictionary<string, IProgressCarreerTransformer> GetProgressCarreerTransformers(string path)
        {
            Dictionary<string, IProgressCarreerTransformer> returnedCollection = new Dictionary<string, IProgressCarreerTransformer>();

            var files = Directory.GetFiles(path);

            foreach (var file in files.Where(t => t.EndsWith(".dll"))) //Only get .dll assemblies
            {
                Assembly assembly = Assembly.LoadFrom(file);
                Type[] types = assembly.GetTypes();

                foreach (Type t in types)
                {
                    if (t.IsClass)
                    {
                        string typeName = t.AssemblyQualifiedName;
                        Type type = Type.GetType(typeName);

                        if (type.GetInterfaces().Contains(typeof(Brevis.Core.IProgressCarreerTransformer)))
                        {
                            Brevis.Core.IProgressCarreerTransformer obj = (IProgressCarreerTransformer)Activator.CreateInstance(type);
                            returnedCollection.Add(t.Assembly.GetName().Name + "." + type.Name, obj);
                        }
                    }
                }
            }

            return returnedCollection;

            throw new ArgumentException("Implementation not found");
        }
    }
}
