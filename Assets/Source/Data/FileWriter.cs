using System.IO;
using System.Threading.Tasks;

namespace Assets.Source.Data
{
    internal abstract class FileWriter
    {
        public abstract Task CreateFile<T>(string filepath, T data);

        public Task DeleteFile(string filepath)
        {
            return Task.Factory.StartNew(() =>
            {
                File.Delete(filepath);
            });
        }

        public abstract Task<T> LoadFile<T>(string filepath) where T : class;
    }
}