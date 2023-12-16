using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper_OOP.Classes
{
    [Serializable]
    public class SerializableObject
    {
        public string ObjectType { get; set; }
        public string SerializedData { get; set; }

        public SerializableObject() { }

        public SerializableObject(string objectType, string serializedData)
        {
            ObjectType = objectType;
            SerializedData = serializedData;
        }
    }
}
