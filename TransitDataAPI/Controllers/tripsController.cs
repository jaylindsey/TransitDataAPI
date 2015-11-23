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
    public class tripsController : ApiController
    {
        private metrotransit_dbEntities db = new metrotransit_dbEntities();

        //// GET: api/trips
        //public IQueryable<trip> Gettrips()
        //{
        //    return db.trips;
        //}

        // GET: api/trips/5
        [ResponseType(typeof(trip))]
        public IHttpActionResult Gettrip(string id)
        {
            var authenticator = new LoginAuthenticator();
            var authenticated = authenticator.AuthenticateRequest(Request.GetQueryNameValuePairs());
            if (authenticated)
            {
                trip trip = db.trips.Find(id);
                if (trip == null)
                {
                    return NotFound();
                }
                return Ok(trip);
            }
            else
            {
                return BadRequest();
            }
        }
        /*
        // PUT: api/trips/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttrip(string id, trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trip.trip_id)
            {
                return BadRequest();
            }

            db.Entry(trip).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tripExists(id))
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

        // POST: api/trips
        [ResponseType(typeof(trip))]
        public IHttpActionResult Posttrip(trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.trips.Add(trip);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tripExists(trip.trip_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trip.trip_id }, trip);
        }

        // DELETE: api/trips/5
        [ResponseType(typeof(trip))]
        public IHttpActionResult Deletetrip(string id)
        {
            trip trip = db.trips.Find(id);
            if (trip == null)
            {
                return NotFound();
            }

            db.trips.Remove(trip);
            db.SaveChanges();

            return Ok(trip);
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

        private bool tripExists(string id)
        {
            return db.trips.Count(e => e.trip_id == id) > 0;
        }
    }
}