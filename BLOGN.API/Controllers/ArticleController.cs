using AutoMapper;
using BLOGN.Data.Services.IService;
using BLOGN.Models;
using BLOGN.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOGN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _categoryService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            var categoriesDto = _mapper.Map<IEnumerable<ArticleDto>>(categories);
            return Ok(categoriesDto);
        }
        [HttpGet("{id}")] // Get id parametresi aldığı için belirtiyoruz
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.Get(id);
            var categoryDto = _mapper.Map<ArticleDto>(category); // Tek bir katagoriyi çağırıyoruz
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ArticleDto categoryDto)
        {
            var category = _mapper.Map<Article>(categoryDto);
            var newArticle = await _categoryService.Add(category);
            return Created(String.Empty, null);// _mapper.Map<ArticleDto>(newArticle));
        }

        [HttpPatch] // Güncelemme
        public async Task<IActionResult> Patch(int id, ArticleDto categoryDto)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var category = _mapper.Map<Article>(categoryDto);
            _categoryService.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _categoryService.Delete(id);
            return NoContent();
        }

    }
}
