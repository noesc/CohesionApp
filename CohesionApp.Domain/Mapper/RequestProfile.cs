using AutoMapper;
using CohesionApp.Data.Entities;
using CohesionApp.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CohesionApp.Domain.Mapper
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<ServiceRequest, RequestDto>();
            CreateMap<ServiceRequest, CreateRequestDto>();
            CreateMap<CreateRequestDto, ServiceRequest>();
            CreateMap<ServiceRequest, UpdateRequestDto>();
            CreateMap<UpdateRequestDto, ServiceRequest>();
        }
    }
}
