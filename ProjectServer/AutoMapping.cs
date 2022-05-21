using AutoMapper;
using DL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectServer
{
    public class AutoMapping : Profile

    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>()
            .ForMember(des => des.FirstName, opts => opts
            .MapFrom(src => src.Person.FirstName))
            .ForMember(des => des.LastName, opts => opts
            .MapFrom(src => src.Person.LastName))
            .ForMember(des => des.Phone, opts => opts
            .MapFrom(src => src.Person.Phone))
            .ForMember(des => des.Email, opts => opts
            .MapFrom(src => src.Person.Email))
            .ForMember(des => des.Country, opts => opts
            .MapFrom(src => src.Person.Country))
            .ForMember(des => des.City, opts => opts
            .MapFrom(src => src.Person.City))
             .ForMember(des => des.Street, opts => opts
             .MapFrom(src => src.Person.Street))
             .ForMember(des => des.HouseNumber, opts => opts
             .MapFrom(src => src.Person.HouseNumber))
             .ForMember(des => des.ApartmentNumber, opts => opts
             .MapFrom(src => src.Person.ApartmentNumber))
             .ForMember(des => des.Identity, opts => opts
             .MapFrom(src => src.Person.Identity))
   .ReverseMap();

            CreateMap<PortfolioFolder, PortfolioFolderDTO>() 
                        .ForMember(des => des.Name, opts => opts
                        .MapFrom(src => src.Folder.Name))
  .ReverseMap();

            CreateMap<Portfolio, PortfolioDTO>()
                       .ForMember(des => des.Type, opts => opts
                       .MapFrom(src => src.Type.Name))
                       .ForMember(des => des.PortfolioTypeId, opts => opts
                       .MapFrom(src => src.Type.Id))
                        .ForMember(des => des.Description, opts => opts
                       .MapFrom(src => src.Status.Description))
 .ReverseMap();


        }
    }
}
