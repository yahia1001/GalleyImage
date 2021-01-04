using GalleryImage.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryImage.Client.Helper
{
    public interface IRepository
    {
        Task CreateImage(Image image);

        Task<IEnumerable<string>> GetImages();
    }
}
