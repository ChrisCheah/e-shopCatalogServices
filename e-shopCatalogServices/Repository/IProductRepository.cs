using e_shopCatalogServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_shopCatalogServices.Repository
{
  public  interface IProductRepository
{
        void SaveProduct(Product product);
        IEnumerable<Product> GetaAll();
        Product GetProductById(long id);
    }
}
