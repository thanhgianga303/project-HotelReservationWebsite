using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Models.IRepositories;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper, IEmployeeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAll(string searchString = null)
        {
            var employees = await _repository.GetEmployees(searchString);
            var employeesDTO = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetBy(int id)
        {
            var employee = await _repository.GetBy(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDTO = _mapper.Map<Employee, EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            await _repository.Add(employee);
            return CreatedAtAction(nameof(GetBy), new { id = employee.EmployeeID }, employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.EmployeeID)
            {
                return BadRequest();
            }
            try
            {
                var employee = _mapper.Map<EmployeeDTO, Employee>(employeeDTO);
                await _repository.Update(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        private async Task<bool> EmployeeExists(int id)
        {
            var employee = await _repository.GetBy(id);
            if (employee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findEmployee = await _repository.GetBy(id);
            if (findEmployee == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }
    }
}