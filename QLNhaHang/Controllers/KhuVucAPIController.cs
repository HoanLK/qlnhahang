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
    public class KhuVucAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/KhuVucAPI
        public IQueryable<KhuVuc> GetKhuVucs()
        {
            return db.KhuVucs;
        }

        // GET: api/KhuVucAPI/5
        [ResponseType(typeof(KhuVuc))]
        public IHttpActionResult GetKhuVuc(int id)
        {
            KhuVuc khuVuc = db.KhuVucs.Find(id);
            if (khuVuc == null)
            {
                return NotFound();
            }

            return Ok(khuVuc);
        }

        // PUT: api/KhuVucAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKhuVuc(int id, KhuVuc khuVuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != khuVuc.IDKhuVuc)
            {
                return BadRequest();
            }

            db.Entry(khuVuc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhuVucExists(id))
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

        // POST: api/KhuVucAPI
        [ResponseType(typeof(KhuVuc))]
        public IHttpActionResult PostKhuVuc(KhuVuc khuVuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KhuVucs.Add(khuVuc);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = khuVuc.IDKhuVuc }, khuVuc);
        }

        // DELETE: api/KhuVucAPI/5
        [ResponseType(typeof(KhuVuc))]
        public IHttpActionResult DeleteKhuVuc(int id)
        {
            KhuVuc khuVuc = db.KhuVucs.Find(id);
            if (khuVuc == null)
            {
                return NotFound();
            }

            db.KhuVucs.Remove(khuVuc);
            db.SaveChanges();

            return Ok(khuVuc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhuVucExists(int id)
        {
            return db.KhuVucs.Count(e => e.IDKhuVuc == id) > 0;
        }
    }
}