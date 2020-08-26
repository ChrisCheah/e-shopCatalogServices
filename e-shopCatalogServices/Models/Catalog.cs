using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_shopCatalogServices.Models
{
    [Table("Catalog")]
    public class Catalog
   {
        private List<Product> productList;
        [Key]
        public long CatalogId { get; set; }
        [Required]
        [StringLength(maximumLength:50,MinimumLength =5)]  
        [Display(Name="Catalog Name")]
        public string Name { get; set; }
        private ILazyLoader _lazyLoader { get; set; }

        public Catalog(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public List<Product> ProductList
        {
            get => _lazyLoader?.Load(this, ref productList);
            set => productList = value;
        }
    }
}
