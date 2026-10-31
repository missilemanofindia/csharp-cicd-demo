using System;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class CalculateController : Controller
    {
        // GET: Calculate
        // This just loads the initial page
        public ActionResult Index()
        {
            return View();
        }

        // POST: Calculate
        // This catches the data sent from the View form
        [HttpPost]
        public ActionResult Index(double num1, double num2, string operation)
        {
            double result = 0;
            bool success = true;

            switch (operation)
            {
                case "Addition":
                    result = num1 + num2;
                    break;
                case "Subtraction":
                    result = num1 - num2;
                    break;
                case "Multiplication":
                    result = num1 * num2;
                    break;
                case "Division":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        ViewBag.Error = "Cannot divide by zero.";
                        success = false;
                    }
                    break;
                default:
                    ViewBag.Error = "Invalid Operation Selected.";
                    success = false;
                    break;
            }

            // If calculations went fine, pass inputs and output back to the View
            if (success)
            {
                ViewBag.Result = result;
            }

            // Keep the entered values in the text boxes so they don't disappear
            ViewBag.Num1 = num1;
            ViewBag.Num2 = num2;
            ViewBag.SelectedOp = operation;

            return View();
        }
    }
}