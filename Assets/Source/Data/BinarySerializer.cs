using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Source.Data
{
    public static class BinarySerializer
    {
        private static readonly BinaryFormatter binaryFormatter = new();

        public static T BinaryDeserialization<T>(this byte[] byteArray) where T : class
        {
            MemoryStream memoryStream = new(byteArray);
            T @object = binaryFormatter.Deserialize(memoryStream) as T;
            memoryStream.Close();
            return @object;
        }

        public static byte[] BinarySerialization(this object @object)
        {
            MemoryStream memoryStream = new();
            binaryFormatter.Serialize(memoryStream, @object);
            memoryStream.Close();
            return memoryStream.ToArray();
        }
    }
}