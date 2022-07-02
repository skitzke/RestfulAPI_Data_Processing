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
    /// This controller allows SELECT, CREATE, UPDATE, DELETE actions on the suicide statistics database table
    /// </summary>
    public class SuicideRateController : ApiController
    {
        #region SELECT CREATE UPDATE DELETE actions
        /// <summary>
        /// Gets the list of all countries from suicide statistics database table.
        /// </summary>
        /// <returns>Returns all countries from suicide statistics table</returns>
        public IEnumerable<suicide_statistics> GetCountries()
        {
            using (HDIEntities entities = new HDIEntities())
            {
                return entities.suicide_statistics.ToList();
            }
        }

        /// <summary>
        /// Gets a single country based on the ID inputted from suicide statistics database table.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Returns a single country</returns>
        public HttpResponseMessage GetSuicideRateBasedOnID(int id)
        {
            using (HDIEntities entities = new HDIEntities())
            {
                var entity = entities.suicide_statistics.FirstOrDefault(i => i.stat_ID  == id);
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
        /// Creates a new record in the suicide statistics database table.
        /// </summary>
        /// <param name="stats">Database table as an object</param>
        /// <returns>Returns a HttpResponseMessage if the creation was successfull</returns>
        public HttpResponseMessage PostNewCountry([FromBody] suicide_statistics stats)
        {
            try
            {
                using (HDIEntities entities = new HDIEntities())
                {
                    entities.suicide_statistics.Add(stats);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, stats);
                    message.Headers.Location = new Uri(Request.RequestUri + stats.stat_ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Updates a record in the suicide statistics database table based on the inputted id with inputted values
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <param name="stats">Database table as an object</param>
        /// <returns>Returns a HttpResponseMessage if the update was successfull</returns>
        public HttpResponseMessage Put(int id, [FromBody] suicide_statistics stats)
        {
            try
            {
                using (HDIEntities entities = new HDIEntities())
                {
                    var entity = entities.suicide_statistics.FirstOrDefault(s => s.stat_ID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Country with ID = " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.country= stats.country;
                        entity.year = stats.year;
                        entity.sex = stats.sex;
                        entity.age = stats.age;
                        entity.suicides_no = stats.suicides_no;
                        entity.population = stats.population;
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
        /// Deletes a record from the suicide statistics database table based on the inputted id.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Returns a HttpResponseMessage if the deletion was successfull</returns>
        public HttpResponseMessage DeleteCountry(int id)
        {
            try
            {
                using (HDIEntities entities = new HDIEntities())
                {
                    var entity = entities.suicide_statistics.FirstOrDefault(s => s.stat_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Country with ID = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.suicide_statistics.Remove(entity);
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
