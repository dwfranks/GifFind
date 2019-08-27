using AutoMapper;
using GifFind.API.Entities;
using GifFind.API.Models.DTO;
using GifFind.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifFind.API.Controllers
{
    [ApiVersionNeutral]
    [Route("api/categories/{categoryId}/[controller]")]
    [ApiController]
    public class SavedImagesController : ControllerBase
    {
        private readonly ISavedImageService _savedImageService;
        private readonly IMapper _mapper;

        public SavedImagesController(ISavedImageService savedImageService, IMapper mapper)
        {
            this._savedImageService = savedImageService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSavedImages(Guid categoryId)
        {
            var images = await _savedImageService.GetSavedImages(categoryId);

            if (images == null || images.Count().Equals(default))
            {
                return NoContent();
            }

            var mappedImages = _mapper.Map<IEnumerable<SaveImageForGet>>(images);

            return Ok(mappedImages);

        }

        [HttpGet("{id}", Name = "GetImage")]
        public async Task<IActionResult> GetImage(Guid id)
        {
            var image = await _savedImageService.GetSavedImage(id);

            if (image == null)
            {
                return NotFound();
            }

            var mappedImage = _mapper.Map<SaveImageForGet>(image);

            return Ok(mappedImage);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSavedImage([FromBody] GifImage image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imagedMapped = _mapper.Map<SavedImage>(image);

            await _savedImageService.SaveImage(imagedMapped);


            return Created("", imagedMapped);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            await _savedImageService.DeleteImage(id);

            return NoContent();
        }
    }
}
