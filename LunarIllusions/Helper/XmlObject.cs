using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LunarIllusions.Helper
{
    class XmlObject<T>
    {
        /*Xml serializing an object*/
        //public static T Load(String path)
        //{
        //    Type type = typeof(T);
        //    T instance;
        //    using (TextReader reader = new StreamReader(path))
        //    {
        //        XmlSerializer xml = new XmlSerializer(type);
        //        instance = (T)xml.Deserialize(reader);
        //    }
        //    return instance;
        //}

        //public static void Save(string path, object obj)
        //{
        //    Type type = typeof(T);
        //    using (TextWriter writer = new StreamWriter(path))
        //    {
        //        XmlSerializer xml = new XmlSerializer(type);
        //        xml.Serialize(writer, obj);
        //    }
        //}

        /*Think about converting to JSON object and using Newtonsoft library*/

        public static void Save(string path, object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamReader reader = new StreamReader(memoryStream))
            {
                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
                serializer.WriteObject(memoryStream, obj);
                memoryStream.Position = 0;
                File.WriteAllText(path,reader.ReadToEnd());
            }
        }

        public static T Load(string path)
        {
            Type toType = typeof(T);
            
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(@"GameObjectsData\" + path));
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(toType);
                return (T)deserializer.ReadObject(stream);
            }
        }
    }
}
