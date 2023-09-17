using AutoMapper;
using BlazorApp.Models;
using BlazorApp.DTO;

namespace BlazorApp.Services
{
    public interface IMapperService
    {
        IMapper Map { get; set;}

    }

    public class MapperService : IMapperService
    {
        //public IMapper _mapper;
        public MapperService(
            IMapper mapper
        ) {
            Map =mapper;
        }

        public IMapper Map { 
            get; 
            set;
        }

        public async Task Initialize()
        {
            List<Organizer> oo= new List<Organizer>();
            //var dd= _mapper.Map<List<OrganizerDto>>(oo);
        }


        
    }
}