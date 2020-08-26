using e_shopCatalogServices.EFContext;
using e_shopCatalogServices.Models;
using e_shopCatalogServices.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_shopCatalogServices.Repository
{
    public class CatalogRepository :IDisposable,ICatalogRepository
    {
        private DataContext _context;


        public CatalogRepository(DataContext context)
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


        public IEnumerable<Catalog> GetaAll()
        {
            return _context.Catalogs;
        }

        public Catalog GetCatalogById(long id)
        {
            var query = from Catalog cat in _context.Catalogs.ToList()
                        where cat.CatalogId == id
                        select cat;
            return query.ToList<Catalog>().First();
        }

        public void SaveCatalog(Catalog catalog)
        {

           _context.Add(catalog);
            _context.SaveChanges();

        }
    }
}
