using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryImage.Client.Helper
{
    public interface IHttpService
    {
        //Task<HttpResponseWrapper<bool>> DeleteFileAsync<T>(string url, string filePath);
        Task<HttpResponseWrapper<bool>> DeleteFileAsync<T>(string url, string filePath);

        //Task<HttpResponseWrapper<bool>> DeleteFileAsync<T>(string url, string filePath);
        Task<HttpResponseWrapper<T>> GetFilesAsync<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data);
    }
}

