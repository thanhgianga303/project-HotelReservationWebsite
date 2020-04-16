using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        private readonly IMapper _mapper;
        public PromotionController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetAll()
        {
            // IEnumerable city = _context.Cities.ToList().AsEnumerable();
            // return await _mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(city);
            return await _context.Promotions.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDTO>> GetBy(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);
            if (promotion == null) return NotFound();
            return _mapper.Map<Promotion, PromotionDTO>(promotion);
        }
        [HttpPost]
        public async Task<ActionResult<Promotion>> Create(PromotionDTO promotionDTO)
        {
            var promotion = _mapper.Map<PromotionDTO, Promotion>(promotionDTO);
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBy), new { id = promotion.PromotionID }, promotion);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PromotionDTO promotionDTO)
        {
            if (id != promotionDTO.PromotionID)
            {
                return BadRequest();
            }

            try
            {
                _context.Promotions.Update(_mapper.Map<PromotionDTO, Promotion>(promotionDTO));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionExists(id))
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
        private bool PromotionExists(int id)
        {
            return _context.Promotions.Any(m => m.PromotionID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findPromotion = await _context.Promotions.FindAsync(id);
            if (findPromotion == null)
            {
                return NotFound();
            }
            _context.Promotions.Remove(findPromotion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}