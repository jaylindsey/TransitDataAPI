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
    public class shapesController : ApiController
    {
        private metrotransit_dbEntities db = new metrotransit_dbEntities();

        // GET: api/shapes
        //public IQueryable<shape> Getshapes()
        //{
        //    return db.shapes;
        //}

        // GET: api/shapes/5
        [ResponseType(typeof(shape))]
        public IHttpActionResult Getshape(int id)
        {
            var authenticator = new LoginAuthenticator();
            var authenticated = authenticator.AuthenticateRequest(Request.GetQueryNameValuePairs());
            if (authenticated)
            {
                shape shape = db.shapes.Find(id);
                if (shape == null)
                {
                    return NotFound();
                }

                return Ok(shape);
            }
            else
            {
                return BadRequest();
            }
        }
        /*
        // PUT: api/shapes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putshape(int id, shape shape)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shape.shape_id)
            {
                return BadRequest();
            }

            db.Entry(shape).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!shapeExists(id))
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

        // POST: api/shapes
        [ResponseType(typeof(shape))]
        public IHttpActionResult Postshape(shape shape)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.shapes.Add(shape);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (shapeExists(shape.shape_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = shape.shape_id }, shape);
        }

        // DELETE: api/shapes/5
        [ResponseType(typeof(shape))]
        public IHttpActionResult Deleteshape(int id)
        {
            shape shape = db.shapes.Find(id);
            if (shape == null)
            {
                return NotFound();
            }

            db.shapes.Remove(shape);
            db.SaveChanges();

            return Ok(shape);
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

        private bool shapeExists(int id)
        {
            return db.shapes.Count(e => e.shape_id == id) > 0;
        }
    }
}