using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MapEditor.Helper
{
    class XmlObject<T>
    {
        public static T Load(String path)
        {
            Type type = typeof(T);
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(type);
                instance = (T)xml.Deserialize(reader);

            }
            return instance;
        }

        public static void Save(string path, object obj)
        {
            Type type = typeof(T);
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
