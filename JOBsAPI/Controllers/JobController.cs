using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleJobAPI.Data;
using SimpleJobAPI.DTOs;
using SimpleJobAPI.Models;
using System;

namespace SimpleJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public JobsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _context.Jobs
                .Include(j => j.AssignedUsers) // Include related assigned users with their information
                .ThenInclude(ua => ua.User) // Include the User details for each assignment
                .ToListAsync();

            var jobDtos = _mapper.Map<IEnumerable<JobDTO>>(jobs);

            return Ok(jobDtos);
        }


        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] JobDTO jobDto)
        {
            var job = _mapper.Map<Job>(jobDto);
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            // Map the created job back to JobDTO
            var createdJobDto = _mapper.Map<JobDTO>(job);

            // Construct the route URL manually
            return CreatedAtAction("GetJobs", new { id = createdJobDto.JobID }, createdJobDto);
        }


        
    }
}
