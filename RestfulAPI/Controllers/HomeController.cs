using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RestfulAPI.Controllers
{
    /// <summary>
    /// This controller is Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        ///  Home API
        /// </summary>
        /// <returns>Return Home Page</returns>
        public ActionResult Index()
        {
            JObject HDI;
            String HDISchema;

            using (StreamReader r = new StreamReader(HttpContext.Server.MapPath("json/HDI.json")))
            {
                string json = r.ReadToEnd();
                HDI = JsonConvert.DeserializeObject<JObject>(json);
            }
            using (StreamReader r = new StreamReader(HttpContext.Server.MapPath("json/HDISchema.json")))
            {
                HDISchema = r.ReadToEnd();
                
            }

            var ValidationErrors= JsonValidator.Validator.Validate(HDI, HDISchema);
            if(ValidationErrors.Count==0)
            {
                //Validation passed
            }
            else
            {
                //Validation failed 
                //display all errors
                foreach(string error in ValidationErrors)
                {
                    ModelState.AddModelError("key",error);

                }
            }
           
            // true
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
