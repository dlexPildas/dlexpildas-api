using System;

namespace DlexPildas.Api.Dtos.ArticlesDtos
{
    public class ArticleCreateDto
    {
        public string Theme { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate = DateTime.Now;
    }
}