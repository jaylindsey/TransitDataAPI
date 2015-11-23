using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TransitDataAPI.Models;

namespace TransitDataAPI.Controllers
{
    public class RouteDirectionsController : ApiController
    {
        private metrotransit_dbEntities db = new metrotransit_dbEntities();

        // GET: api/RouteDirections
        //public IQueryable<route_directions> Getroute_directions()
        //{
        //    return db.route_directions;
        //}

        // GET: api/RouteDirections/5
        [ResponseType(typeof(route_directions))]
        public IHttpActionResult Getroute_directions(string id)
        {
            var authenticator = new LoginAuthenticator();
            var authenticated = authenticator.AuthenticateRequest(Request.GetQueryNameValuePairs());
            if (authenticated)
            {
                route_directions route_directions = db.route_directions.Find(id);
                if (route_directions == null)
                {
                    return NotFound();
                }

                return Ok(route_directions);
            }
            else
            {
                return BadRequest();
            }
        }
        /*
        // PUT: api/RouteDirections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putroute_directions(string id, route_directions route_directions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != route_directions.route_id)
            {
                return BadRequest();
            }

            db.Entry(route_directions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!route_directionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RouteDirections
        [ResponseType(typeof(route_directions))]
        public IHttpActionResult Postroute_directions(route_directions route_directions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.route_directions.Add(route_directions);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (route_directionsExists(route_directions.route_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = route_directions.route_id }, route_directions);
        }

        // DELETE: api/RouteDirections/5
        [ResponseType(typeof(route_directions))]
        public IHttpActionResult Deleteroute_directions(string id)
        {
            route_directions route_directions = db.route_directions.Find(id);
            if (route_directions == null)
            {
                return NotFound();
            }

            db.route_directions.Remove(route_directions);
            db.SaveChanges();

            return Ok(route_directions);
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool route_directionsExists(string id)
        {
            return db.route_directions.Count(e => e.route_id == id) > 0;
        }
    }
}