namespace FastFood.Core.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper.QueryableExtensions;

    using Data;
    using FastFood.Models;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(/*Action name:*/ "Error", /*Controller name(can be ommited if it is the current one):*/ "Home");
            }

            //мапваме си model към модел от базата, в случая към Category, т.к. създаваме категория

            Category category = this.mapper.Map<Category>(model); // мапни ми към <Category> ето този (model)

            //за да може да се осъществи мапинга от inputModel към Category трябва да се опише Конфигурацията в Profile

            this.context.Categories.Add(category);
            this.context.SaveChanges();

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            //издърпваме всички категории във ViewModel и ги подаваме на View-то
            List<CategoryAllViewModel> categories = this.context
                .Categories //всеки елемент от IQueryable колекцията Categories го превръща в CategoryAllViewModel
                .ProjectTo<CategoryAllViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            //The.ProjectTo<OrderLineDTO>() will tell AutoMapper’s mapping engine to emit a select clause 
            //to the IQueryable that will inform entity framework that it only needs to query the Name column of the Item table,
            //same as if you manually projected your IQueryable to an OrderLineDTO with a Select clause.

            return this.View(categories);
        }
    }
}
