using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_shopCatalogServices.EFContext;
using e_shopCatalogServices.Models;
using Newtonsoft.Json;

namespace e_shopCatalogServices.Repository
{
    public class ProductRepository : IDisposable,IProductRepository
    {
        private DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Product> GetaAll()
        {
            return _context.Products;
        }

        public Product GetProductById(long id)
        {
            var query = from Product prod in _context.Products.ToList()
                        where prod.ProductId == id
                        select prod;
            return query.ToList<Product>().First();
        }

        public void SaveProduct(Product product)
        {
            var query = from Catalog cat in _context.Catalogs.ToList()
                        where cat.CatalogId == product.CatalogRef.CatalogId
                        select cat;
            product.CatalogRef = query.ToList<Catalog>().First();
          
            _context.Add(product);
            _context.SaveChanges();
        }
    }
}
