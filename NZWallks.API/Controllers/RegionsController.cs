using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWallks.API.Models.Domain;
using NZWallks.API.Models.DTO;
using NZWallks.API.Repositories;

namespace NZWallks.API.Controllers
{
    // https://localhost:1234/api/controller
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {

        
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: 
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From DataBase
            var regionsDomain = await regionRepository.GetAllAsync();

            

            // Map Domain Models to DTOs USING AUTOMAPPER
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
            return Ok(regionsDto);
        }


        //GET BY ID
        //GET: https://localhost:1234/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionsDomain = await regionRepository.GetByIdAsync(id);
            if (regionsDomain == null)
            {
                return NotFound();
            }

            //var regionsDto = new RegionDto
            //{
            //    Id = regionsDomain.Id,
            //    Code = regionsDomain.Code,
            //    Name = regionsDomain.Name,
            //    RegionImageUrl = regionsDomain.RegionImageUrl
            //};

            //MAP DOMAIN MODEL TO DTO

            var regionsDto = mapper.Map<RegionDto>(regionsDomain);
            
            return Ok(regionsDto);
        }

        // POST
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                var regionsDomainModel = mapper.Map<Region>(addRegionRequestDto);

                regionsDomainModel = await regionRepository.CreateAsync(regionsDomainModel);

                var regionDto = mapper.Map<RegionDto>(regionsDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }

            
        }


        // PUT
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                // Check The ID
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                // Convert Domain Model to DTO

                var regionDto = mapper.Map<UpdateRegionRequestDto>(regionDomainModel);

                return Ok(regionDto);
            
            
        }


        // DELETE
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Delete([FromRoute] Guid  id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
