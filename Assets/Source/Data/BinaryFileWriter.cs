using System.IO;
using System.Threading.Tasks;

namespace Assets.Source.Data
{
    internal class BinaryFileWriter : FileWriter
    {
        public override Task CreateFile<T>(string filepath, T data)
        {
            if (data == null)
            {
                byte[] bytes = { };
                return File.WriteAllBytesAsync(filepath, bytes);
            }
            else
            {
                byte[] bytes = BinarySerializer.BinarySerialization(data);

                return File.WriteAllBytesAsync(filepath, bytes);
            }
        }

        public override async Task<T> LoadFile<T>(string filepath)
        {
            if (File.Exists(filepath))
            {
                /*using(Stream file = File.Open(filepath, FileMode.Open))
                 {
                     BinaryFormatter bf = new BinaryFormatter();
                     return bf.Deserialize(file) as T;
                 }*/

                byte[] bytes = await File.ReadAllBytesAsync(filepath);

                var output = bytes.BinaryDeserialization<T>();
                return output;
            }
            else
            {
                return null;
            }
        }
    }
}