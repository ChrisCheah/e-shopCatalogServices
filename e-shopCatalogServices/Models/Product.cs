using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_shopCatalogServices.Models
{
    [Table("E_Product")]
    public class Product
{
        [Key]
        public long ProductId { get; set; }
        [Required]
        [StringLength(maximumLength:50,MinimumLength =5)]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Purchase Date")]
        public DateTime DOP { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Product Cost")]
        public long Cost { get; set; }
        [ForeignKey("Catalog_Id")]
        [JsonIgnore]
        public Catalog CatalogRef { get; set; }
}
}
