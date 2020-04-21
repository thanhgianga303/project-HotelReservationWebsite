using System.Collections;
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
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;
        public PromotionController(IMapper mapper, IPromotionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionDTO>>> GetAll(string searchString)
        {
            var promotions = await _repository.GetPromotions(searchString);
            var promotionsDTO = _mapper.Map<IEnumerable<Promotion>, IEnumerable<PromotionDTO>>(promotions);
            return Ok(promotionsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDTO>> GetBy(int id)
        {
            var promotion = await _repository.GetBy(id);
            if (promotion == null) return NotFound();
            var promotionDTO = _mapper.Map<Promotion, PromotionDTO>(promotion);
            return Ok(promotionDTO);
        }
        [HttpPost]
        public async Task<ActionResult<Promotion>> Create(PromotionDTO promotionDTO)
        {
            var promotion = _mapper.Map<PromotionDTO, Promotion>(promotionDTO);
            await _repository.Add(promotion);
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
                var promotion = _mapper.Map<PromotionDTO, Promotion>(promotionDTO);
                await _repository.Update(id, promotion);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PromotionExists(id))
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
        private async Task<bool> PromotionExists(int id)
        {
            var promotion = await _repository.GetBy(id);
            if (promotion != null)
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
            var findPromotion = await _repository.GetBy(id);
            if (findPromotion == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }
    }
}