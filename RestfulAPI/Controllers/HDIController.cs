using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HDIDataAccess;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace RestfulAPI.Controllers
{
    /// <summary>
    ///     This controller allows SELECT, CREATE, UPDATE, DELETE actions on the HDI database table
    /// </summary>
    public class HDIController : ApiController
    {
        #region SELECT CREATE UPDATE DELETE actions

        /// <summary>
        ///     Gets the list of all countries from HDI database table.
        /// </summary>
        /// <returns>Returns a list of countries</returns>
        public IEnumerable<development_index> GetCountries()
        {
            using (var entities = new HDIEntities())
            {
                return entities.development_index.ToList();
            }
        }

//
/// <summary>
///     Gets a single country based on the ID inputted from HDI database table.
/// </summary>
/// <param name="id">Unique identifier</param>
/// <returns>Returns a single country</returns>
/// <description>test</description>
public HttpResponseMessage GetCountry(int id)
        {
            using (var entities = new HDIEntities())
            {
                entities.Database.Connection.Open();
                var entity = entities.development_index.FirstOrDefault(hdi => hdi.HDI_ID == id);
                // Display an error message if the Id does not exist
                if (entity != null)
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Country with ID = " + id + " not found");
            }
        }

/// <summary>
///     Creates a new record in the HDI database table.
/// </summary>
/// <param name="DevIndex">Database table as an object</param>
/// <returns>Returns a HttpResponseMessage if the creation was successfull</returns>
public HttpResponseMessage PostNewCountry([FromBody] development_index DevIndex)
        {
            try
            {
                var schema = JSchema.Parse(@"{
                  'type': 'object',
                  'properties': {
                    'name': {'type':'string'},
                    'roles': {'type': 'array'}
                  }
                }");

                var user = JObject.Parse(@"{
                  'name': 'Arnie Admin',
                  'roles': ['Developer', 'Administrator']
                }");
                var valid = user.IsValid(schema);
                // true


                using (var entities = new HDIEntities())
                {
                    entities.development_index.Add(DevIndex);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, DevIndex);
                    message.Headers.Location = new Uri(Request.RequestUri + DevIndex.HDI_ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

/// <summary>
///     Updates a record in the HDI database table based on the inputted id with inputted values.
/// </summary>
/// <param name="id">Unique identifier</param>
/// <param name="DevIndex">Database table as an object</param>
/// <returns>Returns a HttpResponseMessage if the update was successfull</returns>
public HttpResponseMessage Put(int id, [FromBody] development_index DevIndex)
        {
            try
            {
                using (var entities = new HDIEntities())
                {
                    var entity = entities.development_index.FirstOrDefault(hdi => hdi.HDI_ID == id);

                    if (entity == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Country with ID = " + id + " not found to update");

                    entity.HDI_Rank = DevIndex.HDI_Rank;
                    entity.Country = DevIndex.Country;
                    entity.C2010 = DevIndex.C2010;
                    entity.C2011 = DevIndex.C2011;
                    entity.C2012 = DevIndex.C2012;
                    entity.C2013 = DevIndex.C2013;
                    entity.C2014 = DevIndex.C2014;
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

/// <summary>
///     Deletes a record from the HDI database table based on the inputted id.
/// </summary>
/// <param name="id">Unique identifier</param>
/// <returns>Returns a HttpResponseMessage if the deletion was successfull</returns>
public HttpResponseMessage DeleteCountry(int id)
        {
            try
            {
                using (var entities = new HDIEntities())
                {
                    var entity = entities.development_index.FirstOrDefault(hdi => hdi.HDI_ID == id);
                    if (entity == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Country with ID = " + id + " not found to delete");

                    entities.development_index.Remove(entity);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
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