using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HDIDataAccess;

namespace RestfulAPI.Controllers
{
    /// <summary>
    /// This controller allows SELECT, CREATE, UPDATE, DELETE actions on the unemployment rate database table.
    /// </summary>
    public class UnemploymentRateController : ApiController
    {
        #region SELECT CREATE UPDATE DELETE actions
        /// <summary>
        /// Gets the list of all countries from umeployment rates database table.
        /// </summary>
        /// <returns>Returns all coutnries from umeployment rates table</returns>
        public IEnumerable<unemployment_rates> GetCountries()
        {
            using (HDIEntities entities = new HDIEntities())
            {
                return entities.unemployment_rates.ToList();
            }
        }

        /// <summary>
        /// Gets a single country based on the ID inputted from umeployment rates database table.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Returns a single country</returns>
        public HttpResponseMessage GetUnemploymentRateOnID(int id)
        {
            using (HDIEntities entities = new HDIEntities())
            {
                var entity = entities.unemployment_rates.FirstOrDefault(u => u.rate_ID == id);
                // Display an error message if the Id does not exist
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Country with ID = " + id.ToString() + " not found");
                }
            }
        }

        /// <summary>
        /// Creates a new record in the umeployment rates database table.
        /// </summary>
        /// <param name="rate">Database table as an object</param>
        /// <returns>Returns a HttpResponseMessage if the creation was successfull</returns>
        public HttpResponseMessage PostNewCountry([FromBody] unemployment_rates rate)
        {
            try
            {
                using (HDIEntities entities = new HDIEntities())
                {
                    entities.unemployment_rates.Add(rate);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, rate);
                    message.Headers.Location = new Uri(Request.RequestUri + rate.rate_ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Updates a record in the umeployment rates database table based on the inputted id with inputted values.
        /// </summary>
        /// <param name="id">Unique Identifier</param>
        /// <param name="rate">Database table as an object</param>
        /// <returns>Returns a HttpResponseMessage if the update was successfull</returns>
        public HttpResponseMessage Put(int id, [FromBody] unemployment_rates rate)
        {
            try
            {
                using (HDIEntities entities = new HDIEntities())
                {
                    var entity = entities.unemployment_rates.FirstOrDefault(u => u.rate_ID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Country with ID = " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.Country_Name= rate.Country_Name;
                        entity.Country_Code = rate.Country_Code;
                        entity.C2010 = rate.C2010;
                        entity.C2011 = rate.C2011;
                        entity.C2012 = rate.C2012;
                        entity.C2013 = rate.C2013;
                        entity.C2014 = rate.C2014;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Deletes a record from the umeployment rates database table based on the inputted id.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Returns a HttpResponseMessage if the deletion was successfull</returns>
        public HttpResponseMessage DeleteCountry(int id)
        {
            try
            {
                using (HDIEntities entities = new HDIEntities())
                {
                    var entity = entities.unemployment_rates.FirstOrDefault(u => u.rate_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Country with ID = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.unemployment_rates.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion
    }
}
