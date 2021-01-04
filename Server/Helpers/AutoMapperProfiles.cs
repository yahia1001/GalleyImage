using AutoMapper;
using GalleryImage.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallery.Server.Helpers
{
    public class AutoMapperProfiles
    {
        public class AutomapperProfiles : Profile
        {
            public AutomapperProfiles()
            {
                CreateMap<Image, Image>()
                   .ForMember(x => x.Poster, option => option.Ignore());

               
            }

        }
    }
}
