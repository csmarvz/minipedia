using System.Linq;
using System.Collections.Generic;
using Minipedia.Data;
using Minipedia.Models;

namespace Minipedia.Services
{
    public class MinipediaService
    {
        private MinipediaContext _context;

        public MinipediaService(MinipediaContext context)
        {
            _context = context;
        }

        public int AddArticle(ArticleViewModel article)
        {
            var id = _context.Articles.Any() ? _context.Articles.Max(x => x.Id) + 1 : 1;
            _context.Articles.Add(new Article { Id = id, Title = article.Title, Content = article.Content });

            return id;
        }

        public ArticleViewModel GetArticle(int id)
        {
            return _context.Articles.Where(x => x.Id == id).Select(x => new ArticleViewModel { Id = x.Id, Title = x.Title, Content = x.Content }).FirstOrDefault();
        }

        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            return _context.Articles.Select(x => new ArticleViewModel { Id = x.Id, Title = x.Title, Content = x.Content });
        }
    }
}