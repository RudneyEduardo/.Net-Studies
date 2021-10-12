using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlataformService.Data;
using PlataformService.Dtos;
using PlataformService.Models;

namespace PlataformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformsController : ControllerBase
    {
        private readonly IPlataformRepo _repository;
        private readonly IMapper _mapper;

        public PlataformsController(IPlataformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlataformReadDto>> GetPlataforms()
        {
            Console.WriteLine("--> Getting Plataforms...");

            var plataformItem = _repository.GetAllPlataforms();

            return Ok(_mapper.Map<IEnumerable<PlataformReadDto>>(plataformItem));
        }

        [HttpGet("{id}", Name = "GetPlataformById")]
        public ActionResult<PlataformReadDto> GetPlataformById(int id)
        {
            var plataformItem = _repository.GetPlataformById(id);
            if (plataformItem != null)
            {
                return Ok(_mapper.Map<PlataformReadDto>(plataformItem));
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult<PlataformReadDto> CreatePlataform(PlataformCreateDto plataformCreateDto)
        {
            var platformModel = _mapper.Map<Plataform>(plataformCreateDto);

            _repository.CreatePlataform(platformModel);
            _repository.SaveChanges();

            var plataformReadDto = _mapper.Map<PlataformReadDto>(platformModel);

            return CreatedAtRoute(nameof(GetPlataformById), new { Id = plataformReadDto.Id}, plataformReadDto);
        }


    }
}