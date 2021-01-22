using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.DTOs;

namespace Test
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<List<Session>, List<SessionDTO>>().ReverseMap();
            CreateMap<Session, SessionDTO>().ReverseMap();
        }
    }
}
