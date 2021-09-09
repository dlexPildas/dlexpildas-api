using System;

namespace DlexPildas.Api.Dtos.ArticlesDtos
{
    public class ArticleUpdateDto
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}