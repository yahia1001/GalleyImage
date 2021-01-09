using GalleryImage.Client.Helper;
using GalleryImage.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GalleryImage.Client.Pages
{
    public partial class GalleryAdmin
    {
       [Inject] IRepository rep { get; set; }

        List<string> imageURL = new List<string>(); 
        protected override async Task OnInitializedAsync()
        {
            try
            {
                imageURL = (await rep.GetImages()).ToList();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }

        private async Task DeleteAction(string filePath)
        {
            try
            {
                await rep.DeleteImage(filePath);

            }
            catch (global::System.Exception ex)
            {

                global::System.Console.WriteLine(ex);
            }
        }

    }
}