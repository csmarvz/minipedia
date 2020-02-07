using System.Collections.Generic;

namespace Minipedia.Data
{
    public class MinipediaContext
    {
        public List<Article> Articles { get; } = new List<Article>();
    }
}