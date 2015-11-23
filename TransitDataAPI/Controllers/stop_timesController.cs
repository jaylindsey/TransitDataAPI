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
    public class stop_timesController : ApiController
    {
        private metrotransit_dbEntities db = new metrotransit_dbEntities();

        // GET: api/stop_times
        //public IQueryable<stop_times> Getstop_times()
        //{
        //    return db.stop_times;
        //}

        // GET: api/stop_times/5
        [ResponseType(typeof(stop_times))]
        public IHttpActionResult Getstop_times(string id)
        {
            var authenticator = new LoginAuthenticator();
            var authenticated = authenticator.AuthenticateRequest(Request.GetQueryNameValuePairs());
            if (authenticated)
            {
                stop_times stop_times = db.stop_times.Find(id);
                if (stop_times == null)
                {
                    return NotFound();
                }

                return Ok(stop_times);
            }
            else
            {
                return BadRequest();
            }
        }
        /*
        // PUT: api/stop_times/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putstop_times(string id, stop_times stop_times)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stop_times.trip_id)
            {
                return BadRequest();
            }

            db.Entry(stop_times).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!stop_timesExists(id))
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

        // POST: api/stop_times
        [ResponseType(typeof(stop_times))]
        public IHttpActionResult Poststop_times(stop_times stop_times)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.stop_times.Add(stop_times);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (stop_timesExists(stop_times.trip_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stop_times.trip_id }, stop_times);
        }

        // DELETE: api/stop_times/5
        [ResponseType(typeof(stop_times))]
        public IHttpActionResult Deletestop_times(string id)
        {
            stop_times stop_times = db.stop_times.Find(id);
            if (stop_times == null)
            {
                return NotFound();
            }

            db.stop_times.Remove(stop_times);
            db.SaveChanges();

            return Ok(stop_times);
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

        private bool stop_timesExists(string id)
        {
            return db.stop_times.Count(e => e.trip_id == id) > 0;
        }
    }
}