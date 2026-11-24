using Microsoft.AspNetCore.Mvc;
using MVC01.Models;

namespace MVC01.Controllers
{
    //CLR Create the Obj From this class By Services
    //[Route("[controller]/bdoor/[action]")]
    public class ProductsController : Controller
    {
        // Functions -- Methods -- Actions -- Endpoint -- APIs --> Are Same Thing

        // BaseURL / ControlerName / Action (Function Name) -->Route Battern

        #region Actions

        // Actions : public [Non-Static] Methods 
        // Must be public, Non-Static (Object Member Method), Non Genaric
        // Action Results : Built-In Datatype Used As Action Return Type 
        //        Ex      : JSONResult  --> Return JSON 
        //                  ViewResult  --> HTML Page
        //                  FileContentResult
        //                  RedirectResult
        // ## All This Datatypes have One Parent Named [ActionResult] --> Implement Interface Named [IActionResult]##
        //      ** By Using It As a ReturnType you can Return Many Types Of Data as you want ** 
        // Helper method : helps you to not create obj yourself [[[RECOMMENDED]]]
        //     Instead of: JSONResult  --> JSON 
        //                  ViewResult --> View
        //                  FileContentResult --> FileContent
        //                  RedirectResult --> Redirect
        // Verb : [HttpGet] , [HttpPost] : Determain Identify of Actions
        // [HttpGet] // Defualt, Only-Understood For Browser 
        // [HttpPost] // Error 404. Truly It Must throw Erroe 500
        #endregion

        public Product GetProductById(int id)
        {
            // Logic --> Open Connection with DB
            return new Product() { Id = id, Name = "IPhone", Price = 300 }; // --> Return JSON
        }

        //BaseURL/Products/GetProducts
        //public List<Product> GetProducts()
        //{
        //    return new List<Product>()
        //    {
        //        new Product () {Id = 1,Name = "Ramsung",Price = 10},
        //        new Product () {Id = 2,Name = "Tamsung",Price = 20},
        //        new Product () {Id = 3,Name = "Oamsung",Price = 30},
        //        new Product () {Id = 4,Name = "Vamsung",Price = 40},
        //    };
        //}

        //[HttpGet("fun1")]
        public JsonResult GetProducts()
        {
            return new JsonResult(new List<Product>()
            {
                new Product () {Id = 1,Name = "Ramsung",Price = 10},
                new Product () {Id = 2,Name = "Tamsung",Price = 20},
                new Product () {Id = 3,Name = "Oamsung",Price = 30},
                new Product () {Id = 4,Name = "Vamsung",Price = 40},
            });
        }

        [HttpGet]
        public ViewResult Index()
        {
            return new ViewResult();
        }

        [HttpGet] // BaseURL/Products/GetFile
        public FileContentResult GetFile()
        {
            var bytes = System.IO.File.ReadAllBytes("wwwroot/files/Note.txt");
            return new FileContentResult(bytes, "application/txt");
        }

        [HttpGet] // BaseURL/Products/RedirectURL
        public RedirectResult RedirectURL()
        {
            return new RedirectResult("https://www.google.com");
        }

        [HttpGet] // BaseURL/Products/RedirectAction

        public RedirectToActionResult RedirectAction()
        {
            return new RedirectToActionResult("RedirectURL", "Products", null);
        }

        // Use ActionResult | IActionResult
        public IActionResult Test(int id)
        {
            if(id == 1)
            {
                return  View(); // helper method : helps you to not create obj yourself [[[RECOMMENDED]]]
            }else if(id == 2)
            {
                return  Json(new Product() { Id = id, Name = "IPhone", Price = 300 });
            }
            else
            {
                //return new RedirectToActionResult("RedirectAction", "Products", null);
                return  RedirectToAction("RedirectAction", "Products", null); // Removeing [new + Result] Make AR helperMethods
            }
        }

    }
}
