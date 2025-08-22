using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using NZWallks.API.Models.Domain;
using NZWallks.API.Models.DTO;

namespace NZWallks.API.Controllers
{
    // /api/Walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }



        // CRETAE Walks
        // POST
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
                // Map DTO to Domain Model
                var walksDomainModel = mapper.Map<Walk>(addWalkRequestDto);


                walksDomainModel = await walkRepository.CreateAsync(walksDomainModel);

                // Map Domain Model to DTO
                var walksDto = mapper.Map<WalkDto>(walksDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = walksDto.Id }, walksDto);
        }


        // Get Walks
        // GET: /walks?filterOn=Nmae&filterQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            // GET Walks From Data base to Domain Model
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, 
                pageNumber, pageSize);

            // Map Domain Model To DTO
            var walksDto = mapper.Map<List<WalkDto>>(walksDomainModel);

            return Ok(walksDto);
        }


        // Get Walk By Id
        // GET
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id )
        {
            // Get Data from Data base
            var walksDomainModel = await walkRepository.GetByIdAsync(id);
            if (walksDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model To DTO
            var walksDto = mapper.Map<WalkDto>(walksDomainModel);
            return Ok(walksDto);
        }


        // Update Walk
        // Put
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto )
        {
            // Map DTO to DomainModel
            var walksDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walksDomainModel = await walkRepository.UpdateAsync(id, walksDomainModel);
            if (walksDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model To DTO
            var walksDto = mapper.Map<WalkDto>(walksDomainModel);
            return Ok(walksDto);
        }



        // Delete Walk
        // Delete
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walksDomainModel = await walkRepository.DeleteAsync(id);
            if (walksDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var walksDto = mapper.Map<WalkDto>(walksDomainModel);
            return Ok(walksDto);
        }
        
    }
}
