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
using QLNhaHang.Models;

namespace QLNhaHang.Controllers
{
    public class ThucDonAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/ThucDonAPI
        public IQueryable<ThucDon> GetThucDons()
        {
            return db.ThucDons;
        }

        // GET: api/ThucDonAPI/5
        [ResponseType(typeof(ThucDon))]
        public IHttpActionResult GetThucDon(int id)
        {
            ThucDon thucDon = db.ThucDons.Find(id);
            if (thucDon == null)
            {
                return NotFound();
            }

            return Ok(thucDon);
        }

        // PUT: api/ThucDonAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThucDon(int id, ThucDon thucDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thucDon.IDThucDon)
            {
                return BadRequest();
            }

            db.Entry(thucDon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThucDonExists(id))
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

        // POST: api/ThucDonAPI
        [ResponseType(typeof(ThucDon))]
        public IHttpActionResult PostThucDon(ThucDon thucDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ThucDons.Add(thucDon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = thucDon.IDThucDon }, thucDon);
        }

        // DELETE: api/ThucDonAPI/5
        [ResponseType(typeof(ThucDon))]
        public IHttpActionResult DeleteThucDon(int id)
        {
            ThucDon thucDon = db.ThucDons.Find(id);
            if (thucDon == null)
            {
                return NotFound();
            }

            db.ThucDons.Remove(thucDon);
            db.SaveChanges();

            return Ok(thucDon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThucDonExists(int id)
        {
            return db.ThucDons.Count(e => e.IDThucDon == id) > 0;
        }
    }
}