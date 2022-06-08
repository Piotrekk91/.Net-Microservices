using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using System;
using System.Collections.Generic;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsContolller : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsContolller(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("-->Getting Platforms...");

            var platformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]

        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatformById(int id)
        {
            Console.WriteLine("-->Getting Platform...");

            var platformItem = _repository.GetPlatformById(id);

            if(platformItem != null)
            {
                return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
            }
            return NotFound();


        }
    }
}
