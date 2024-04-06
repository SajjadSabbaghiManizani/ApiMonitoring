using ApiMonitoring.Application.DTOs.ServerDtos;
using ApiMonitoring.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMonitoring.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<ServerDto, Server>()
            .ReverseMap();
        }
    }
}
