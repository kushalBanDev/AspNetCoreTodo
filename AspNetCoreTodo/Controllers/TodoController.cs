using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        public readonly ITodoItemService _todoItemService;
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        
        public async Task<IActionResult> Index(){
            

            //Get the todo items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();
            //put items into a model
            var model = new TodoViewModel()
            {
                Items = items
            };
           //render into model
           return View(model);           
        }
    }
}
