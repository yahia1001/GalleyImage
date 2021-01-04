using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryImage.Shared.Entities
{
    [Table(nameof(Image))]
    public class Image
    {

       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageID { get; set; }

        public string Imagedescription { get; set; }

        [NotMapped]
        public List<string> Poster { get; set; }

        //[NotMapped]
        //public List<string> Img { get; set; }

    }
}
