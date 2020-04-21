using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingDetailController : ControllerBase
    {
        private readonly IBookingDetailRepository _repository;
        private readonly IMapper _mapper;
        public BookingDetailController(IMapper mapper, IBookingDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetailDTO>>> GetAll(string searchString = null)
        {
            var bookingdetails = await _repository.GetBookingDetails(searchString);
            var bookingdetailsDTO = _mapper.Map<IEnumerable<BookingDetail>, IEnumerable<BookingDetailDTO>>(bookingdetails);
            return Ok(bookingdetailsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetailDTO>> GetBy(int id)
        {
            var bookingdetail = await _repository.GetBy(id);
            if (bookingdetail == null)
            {
                return NotFound();
            }
            var bookingdetailDTO = _mapper.Map<BookingDetail, BookingDetailDTO>(bookingdetail);
            return Ok(bookingdetailDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingDetailDTO bookingdetailDTO)
        {
            var bookingdetail = _mapper.Map<BookingDetailDTO, BookingDetail>(bookingdetailDTO);
            await _repository.Add(bookingdetail);
            return CreatedAtAction(nameof(GetBy), new { id = bookingdetail.BookingDetailID }, bookingdetail);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookingDetailDTO bookingdetailDTO)
        {
            if (id != bookingdetailDTO.BookingDetailID)
            {
                return BadRequest();
            }
            try
            {
                var bookingdetail = _mapper.Map<BookingDetailDTO, BookingDetail>(bookingdetailDTO);
                await _repository.Update(id, bookingdetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BookingDetailExists(id))
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

        private async Task<bool> BookingDetailExists(int id)
        {
            var bookingdetail = await _repository.GetBy(id);
            if (bookingdetail != null)
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
            var findRoom = await _repository.GetBy(id);
            if (findRoom == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }

    }
}