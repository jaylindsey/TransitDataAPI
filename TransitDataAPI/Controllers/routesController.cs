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
    public class RoutesController : ApiController
    {
        private metrotransit_dbEntities db = new metrotransit_dbEntities();

        // GET: api/Routes
        public IQueryable<route> Getroutes()
        {
            var authenticator = new LoginAuthenticator();
            var authenticated = authenticator.AuthenticateRequest(Request.GetQueryNameValuePairs());
            if (authenticated)
            {
                return db.routes; ;
            }
            else
            {
                return db.routes.Where(rt => rt.route_id.Equals(-1));
            }


        }

        // GET: api/Routes/5
        [ResponseType(typeof(route))]
        public IHttpActionResult Getroute(string id)
        {
            var authenticator = new LoginAuthenticator();
            var authenticated = authenticator.AuthenticateRequest(Request.GetQueryNameValuePairs());
            if (authenticated)
            {
                route route = db.routes.Find(id);
                if (route == null)
                {
                    return NotFound();
                }

                return Ok(route);
            }
            else
            {
                return BadRequest();
            }
        }


        /*
        // PUT: api/Routes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putroute(string id, route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != route.route_id)
            {
                return BadRequest();
            }

            db.Entry(route).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!routeExists(id))
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

        // POST: api/Routes
        [ResponseType(typeof(route))]
        public IHttpActionResult Postroute(route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.routes.Add(route);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (routeExists(route.route_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = route.route_id }, route);
        }

        // DELETE: api/Routes/5
        [ResponseType(typeof(route))]
        public IHttpActionResult Deleteroute(string id)
        {
            route route = db.routes.Find(id);
            if (route == null)
            {
                return NotFound();
            }

            db.routes.Remove(route);
            db.SaveChanges();

            return Ok(route);
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

        private bool routeExists(string id)
        {
            return db.routes.Count(e => e.route_id == id) > 0;
        }
    }
}