using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TermPaper_OOP.Classes;
using TermLibrary.Interfaces;

namespace TermPaper_OOP
{
    public static class SVGHandler
    {
        public static void SaveShapesToSVG(List<IDrawableAndSelectable> shapes, string filePath)
        {
            var serializableObjects = shapes.Select(obj =>
            {
                var serializedData = SerializeObject(obj);
                return new SerializableObject(obj.GetType().FullName, serializedData);
            }).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableObject>));

            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, serializableObjects);
            }
        }

        private static string SerializeObject(object obj)
        {
            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        public static List<IDrawableAndSelectable> LoadShapesFromSVG(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableObject>));

            if (!File.Exists(filePath)) return new List<IDrawableAndSelectable>();
            using (TextReader reader = new StreamReader(filePath))
            {
                var serializableObjects = (List<SerializableObject>)serializer.Deserialize(reader);
                return serializableObjects.Select(obj => DeserializeObject(obj)).ToList();
            }
        }

        private static IDrawableAndSelectable DeserializeObject(SerializableObject serializableObject)
        {
            Type objectType = Type.GetType(serializableObject.ObjectType);
            using (StringReader reader = new StringReader(serializableObject.SerializedData))
            {
                XmlSerializer serializer = new XmlSerializer(objectType);
                return (IDrawableAndSelectable)serializer.Deserialize(reader);
            }
        }
    }
}