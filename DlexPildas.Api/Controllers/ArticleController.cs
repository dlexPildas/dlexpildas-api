using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DlexPildas.Api.Dtos.ArticlesDtos;
using DlexPildas.Application.Services.ArticleAggregate;
using DlexPildas.Domain.Models;
using DlexPildas.Persistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DlexPildas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;

        public ArticleController(
            DataContext dataContext, 
            IMapper mapper,
            IArticleService articleService)
        {
            _mapper = mapper;
            _articleService = articleService;
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method to create a new article
        /// </summary>
        /// <param name="articleDto">Object that represent a article</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleCreateDto articleDto)
        {
            try
            {
                var article = _mapper.Map<Article>(articleDto);

                await _articleService.AddArticle(article);

                return this.StatusCode(StatusCodes.Status201Created, "Article was created with success!");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "There was an error to create a article :(");
            }
        }

        /// <summary>
        /// Method to update a article
        /// </summary>
        /// <param name="articleUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateArticle(ArticleUpdateDto articleUpdateDto)
        {
            try
            {
                var articleExists = _dataContext.Articles
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == articleUpdateDto.Id);

                if (articleExists == null)
                    return NotFound("Article not found!");

                var article = _mapper.Map<Article>(articleUpdateDto);

                await _articleService.UpdateArticle(article);

                return Ok("Article was updated with success!");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "There was an error to update a article :(");
            }
        }

        /// <summary>
        /// Method to delete a specific article by Id
        /// </summary>
        /// <param name="id">Article's Id that will be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            try
            {
                var articleExists = _dataContext.Articles
                    .FirstOrDefault(x => x.Id == id);

                if (articleExists == null)
                    return NotFound("Article not found!");

                await _articleService.DeleteArticle(articleExists);

                return Ok("Article was deleted with success!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to return all articles registereds
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllArticles()
        {
            try
            {
                var articles = _dataContext.Articles
                    .ToList();

                return Ok(articles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /// <summary>
        /// Method to return a specific article by id
        /// </summary>
        /// <param name="id">Id of a article</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetArticleById(int id)
        {
            try
            {
                var article = _dataContext.Articles
                .FirstOrDefault(x => x.Id == id);

                if (article == null)
                    return NotFound("Article not found!");

                return Ok(article);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "There was an error to update a article :(");
            }
        }
    }
}