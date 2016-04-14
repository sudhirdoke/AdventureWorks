using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorks.Models;
using Adv.Domain.NHibernate;
using Adv.Domain.NHibernate.Queries;
using AdventureWorks.CommonAttributes;

namespace AdventureWorks.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [UseDefaultValues]
        public ActionResult Index([Default(1)]int? pageNumber, [Default(50)]int? pageSize)
        {
            var products = NHibernateSession.Repository.GetPagedList<Product>(pageNumber, pageSize);
                //NHibernateSession.Repository.ToList<Product>().ToList();
                //NHibernateSession.Repository.FindByQuery(new FindProjectsByProjectNumberQuery("CA-5965"));
                
                //NHibernateSession.Repository.GetById<Product>(1); //NHibernateSession.Repository.FindByQuery<Product>(p => p.Id == 1);
            ProductsIndexModel model = new ProductsIndexModel();
            model.Products = products.Items.ToList();
            model.PageNumber = pageNumber;
            model.PageSize = pageSize;
            model.TotalPages = products.TotalCount / pageSize;
            //foreach (var prod in products)
            //{

            //    model.ProductName = prod.ProductName;
            //    model.Id = prod.Id;
            //    model.ProductNumber = prod.ProductNumber;
            //}
            return View(model);
        }

        public ActionResult ProductDetails(int id)
        {
            var product = NHibernateSession.Repository.GetById<Product>(id);
            ProductsIndexModel model = new ProductsIndexModel();
            model.Products = new List<Product> { product };
            int subCategory = product.ProductSubcategoryID ?? 0;
            int modelId = product.ProductModelID ?? 0;

            var productSubCategory = product.ProductSubcategoryID == null ? null : NHibernateSession.Repository.GetById<ProductSubCategory>(subCategory);
            model.ProductCategory = productSubCategory == null ? null : NHibernateSession.Repository.GetById<ProductCategory>(productSubCategory.ProductCategoryID);
            model.ProductModel = product.ProductModelID == null ? null : NHibernateSession.Repository.GetById<ProductModel>(modelId);

            model.ProductSubCategory = productSubCategory;
            model.ProductUOM = (string.IsNullOrEmpty(product.SizeUnitMeasureCode) ? null : NHibernateSession.Repository.FindByQuery(new FindProductUOMByUOMCodeQuery(product.SizeUnitMeasureCode)).FirstOrDefault());
            return View(model);
        }

        public ActionResult ProductCategoryIndex([Default(1)]int? pageNumber, [Default(50)]int? pageSize)
        {
            var productCategoriesModel = new ProductCategoryIndexModel();
            productCategoriesModel.ProductCategoryList = NHibernateSession.Repository.GetPagedList<ProductCategory>(pageNumber, pageSize).Items.ToList();

            return View(productCategoriesModel);
        }
    }
}