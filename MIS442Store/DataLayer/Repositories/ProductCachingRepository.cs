using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductCachingRepository : LINQProductRepository
    {
        public override Product Get(int id)
        {
            return (base.Get(id));
        }
        public override List<Product> GetList()
        {
            List<Product> product = (List<Product>)HttpRuntime.Cache["Product"];
            if (product == null)
            {
               product = base.GetList();
                HttpRuntime.Cache["Product"] = product;
            }
            return product;
        }
        public override void Save(Product product)
        {
            base.Save(product);
            HttpRuntime.Cache["Product"] = null;
        }
    }
}