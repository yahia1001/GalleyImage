using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallery.Server.Helpers
{
    public interface IfileStorageSrevice
    {
        Task EditFile(byte[] content, string extension, string containerName, string fileRoute);
        Task DeleteFile(string fileRoute, string containerName);
        Task SaveFile(byte[] content, string extension, string containerName);
    }
}
