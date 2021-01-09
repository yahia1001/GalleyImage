using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GalleryImage.Server;
using GalleryImage.Shared.Entities;
using GalleryImage.Server.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gallery.Server.Helpers;
using System.IO;

namespace GalleryImage.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    //[Route("api/[controller")] Wrong
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IfileStorageSrevice fileStorage;
        private readonly IMapper mapper;
        private string ContainerName = "image";
        private byte[] personImage;

        public ImageController(ApplicationDbContext Context, IfileStorageSrevice fileStorage, IMapper mapper)
        {
            this.context = Context;
            this.fileStorage = fileStorage;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("/api/GetFiles")]
        public IEnumerable<string> GetFiles()
        {
            try
            {
                var path = Path.Combine($"wwwroot/image");
                var files = System.IO.Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);

                List<string> vs = new List<string>();
                foreach (string item in files)
                {
                    //string fileName = System.IO.Path.GetFileName(item);
                    string fileName = item.Split(new string[] { "wwwroot" }, StringSplitOptions.None)[1];
                    vs.Add(fileName);
                }
                return vs;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Image image)
        {

            if (image.Poster != null)
            {
                foreach (var img in image.Poster.Distinct())
                {
                    var Image = Convert.FromBase64String(img);
                    await fileStorage.SaveFile(Image, "jpg", ContainerName);
                }
               
            }

            context.Add(image);
            await context.SaveChangesAsync();
            return image.ImageID;

        }

        [HttpGet]
        public async Task<ActionResult<List<Image>>> Get()
        {
            return await context.Images.ToListAsync();
        }

        [HttpDelete]
        [Route("/api/DeleteFile")]
        public IActionResult DeleteFile(string filePath)
        {
            try
            {
                var path = Path.Combine($"wwwroot/image",filePath);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), path);
                System.IO.File.Delete(pathToSave);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
