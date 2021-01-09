using GalleryImage.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryImage.Client.Helper
{
    public class Repository : IRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/Image";

        public Repository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<IEnumerable<string>> GetImages()
        {
            var response = await httpService.GetFilesAsync<IEnumerable<string>>("api/GetFiles");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            else
            {
                return response.Response;
            }
        }

        public async Task CreateImage(Image image)
        {
            var response = await httpService.Post(url, image);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<bool> DeleteImage(string filePath)
        {
            var response = await httpService.DeleteFileAsync<bool>(url,filePath);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            else
            {
                return response.Response;
            }
        }

    }
}
    


