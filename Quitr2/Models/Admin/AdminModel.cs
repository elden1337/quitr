using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quitr2.Models.Admin
{
    public class AdminModel
    {

        public AdminModel()
        {
            Contents = new List<ContentsModel>();
            Products = new List<ProductsModel>();
            Types = new List<TypesModel>();
        }

        public List<TypesModel> Types { get; set; }
        public List<ContentsModel> Contents { get; set; }
        public List<ProductsModel> Products { get; set; }
        public int TypeId { get; set; }
        public string ProductName { get; set; }
        public string ContentName { get; set; }
        public decimal ContentAmount { get; set; }
        public string ContentUnit { get; set; }
    }

    public class ContentsModel
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public string Unit { get; set; }
    }

    public class ProductsModel
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string ProductName { get; set; }
    }

    public class TypesModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }

  

}

