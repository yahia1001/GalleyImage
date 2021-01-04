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
    {//ده بدايه 
        //هنا جوا بتكتب اى فاريابول او فانكشن
       [Inject] IRepository rep { get; set; }//

        List<string> imageURL = new List<string>();//عرفت الفاريابل هنا عشان تقدر تستخدمو ف اى فانكشن 
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
    }//ده نهايه الكلاس
    //مفيش حاجه بتكتبها برا نهايه الكلاس خالص
}
    

    

   


            




   

    

    

    


   




    

