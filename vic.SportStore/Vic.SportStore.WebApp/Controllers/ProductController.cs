using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportStore.WebApp.Models;

namespace Vic.SportStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4;
        public IProductsRepository ProductsRepository { get; set; }


        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = ProductsRepository
               .Products
               .Where(p => category == null || p.Category == category)
               .OrderBy(p => p.ProductId)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository.Products
                    .Where(p => category == null || p.Category == category)
                    .Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}