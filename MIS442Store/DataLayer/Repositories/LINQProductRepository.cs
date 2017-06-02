using MIS442Store.DataLayer.DataModels;
using System;
using MIS442Store.DataLayer.Interfaces;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class LINQProductRepository : IProductRepository
    {
        private MIS442DBDataContext _DataContext = new MIS442DBDataContext();
        public Product Get(int id)
        {
            Product product = null;
            ProductDO productDO = _DataContext.Product_Get(id).SingleOrDefault();
            if (productDO != null)
            {
                product = new Product();
                product.ProductID = productDO.ProductID;
                product.ProductName = productDO.ProductName;
                product.ProductCode = productDO.ProductCode;
                product.ProductVersion = productDO.ProductVersion;
                product.ProductReleaseDate = productDO.ProductReleaseDate;
            }
            return product;


        }
        public List<Product> GetList()
        {
            List<Product> productList = new List<Product>();
            ISingleResult<ProductDO> productDOs = _DataContext.Product_GetList();
            foreach (var p in productDOs)
            {
                Product product = new Product();
                product.ProductID = p.ProductID;
                product.ProductName = p.ProductName;
                product.ProductCode = p.ProductCode;
                product.ProductVersion = p.ProductVersion;
                product.ProductReleaseDate = p.ProductReleaseDate;
                productList.Add(product);
            }
            return productList;


        }
        public void Save(Product product)
        {
            if (product.ProductID == 0)
            {
                _DataContext.Product_InsertUpdate(null, product.ProductCode, product.ProductName, product.ProductVersion, product.ProductReleaseDate);
            }
            else
            {
                _DataContext.Product_InsertUpdate(product.ProductID, product.ProductCode, product.ProductName, product.ProductVersion, product.ProductReleaseDate);
            }


        }
    }
}