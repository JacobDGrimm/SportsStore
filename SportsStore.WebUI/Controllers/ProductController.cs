﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 4;

        public ProductController(IProductRepository productRepsository)
        {
            this.repository = productRepsository;
        }
        
        public ViewResult List(int page = 1)
        {
            ProductsListViewModels model = new ProductsListViewModels
            {
                Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = repository.Products.Count() }
            };
            return View(model);
        }
    }
}