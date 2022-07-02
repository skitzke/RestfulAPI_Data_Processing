using System.IO;
using System.Web.Mvc;
using JsonValidator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestfulAPI.Controllers
{
    /// <summary>
    ///     This controller is Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        ///     Home API
        /// </summary>
        /// <returns>Return Home Page</returns>
        public ActionResult Index()
        {
            JObject HDI;
            string HDISchema;

            using (var r = new StreamReader(HttpContext.Server.MapPath("json/HDI.json")))
            {
                var json = r.ReadToEnd();
                HDI = JsonConvert.DeserializeObject<JObject>(json);
            }

            using (var r = new StreamReader(HttpContext.Server.MapPath("json/HDISchema.json")))
            {
                HDISchema = r.ReadToEnd();
            }

            var ValidationErrors = Validator.Validate(HDI, HDISchema);
            if (ValidationErrors.Count == 0)
            {
                //Validation passed
            }
            else
            {
                //Validation failed 
                //display all errors
                foreach (var error in ValidationErrors) ModelState.AddModelError("key", error);
            }

            // true
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}