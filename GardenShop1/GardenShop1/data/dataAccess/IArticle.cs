using GardenShop1.data.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenShop1.data.dataAccess
{
    public interface IArticle
    {
        bool AddArticle(Article article);
        Article FindByCode(int code);
        List<Article> GetArticles();
        bool DeleteArticle(int code);
        bool UpdateArticle(Article article, string previousCode);
        bool UpdateQuantity(int value, int code);
    }
}
