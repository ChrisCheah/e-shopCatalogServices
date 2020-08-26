using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_shopCatalogServices.Models;
namespace e_shopCatalogServices.Repository
{
    public interface ICatalogRepository
     {
        void SaveCatalog(Catalog catalog);
        IEnumerable<Catalog> GetaAll();
        Catalog GetCatalogById(long id);



      }
}
