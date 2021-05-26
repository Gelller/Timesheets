using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Domain.Implementation;
using System.Security.Cryptography;
using System.Text;

namespace Timesheets
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(x => x.PasswordHash, x => x.MapFrom(x=> UsersManager.GetPasswordHash(x.Password)));
            CreateMap<EmployeeDto, Employee>();
            CreateMap<SheetDto, Sheet>()
                 .ForMember(x => x.Id, x => x.MapFrom(x => Guid.NewGuid()));
            CreateMap<InvoiceDto, Invoice>()
                .ForMember(x => x.Id, x => x.MapFrom(x => Guid.NewGuid()));
        }      
    }  
}
