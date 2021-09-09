using System;

namespace DlexPildas.Domain.Models
{
    public class Article
    {
        public int Id { get; private set; }
        public string Theme { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Content { get; private set; }
        public DateTime CreateDate { get; private set; }
    }
}