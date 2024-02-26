using AutoMapper;
using PonavljanjePosleKursa1.Models.DTO;

namespace PonavljanjePosleKursa1.Models
{
    public class TelefonProfile : Profile
    {
        public TelefonProfile()
        {
            CreateMap<Telefon, TelefonDTO>();
        }
    }
}
