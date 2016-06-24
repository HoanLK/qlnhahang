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
    public class NhaCungCapAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/NhaCungCapAPI
        public IQueryable<NhaCungCap> GetNhaCungCaps()
        {
            return db.NhaCungCaps;
        }

        // GET: api/NhaCungCapAPI/5
        [ResponseType(typeof(NhaCungCap))]
        public IHttpActionResult GetNhaCungCap(int id)
        {
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            return Ok(nhaCungCap);
        }

        // PUT: api/NhaCungCapAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhaCungCap(int id, NhaCungCap nhaCungCap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhaCungCap.IDNhaCungCap)
            {
                return BadRequest();
            }

            db.Entry(nhaCungCap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaCungCapExists(id))
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

        // POST: api/NhaCungCapAPI
        [ResponseType(typeof(NhaCungCap))]
        public IHttpActionResult PostNhaCungCap(NhaCungCap nhaCungCap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhaCungCaps.Add(nhaCungCap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhaCungCap.IDNhaCungCap }, nhaCungCap);
        }

        // DELETE: api/NhaCungCapAPI/5
        [ResponseType(typeof(NhaCungCap))]
        public IHttpActionResult DeleteNhaCungCap(int id)
        {
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            db.NhaCungCaps.Remove(nhaCungCap);
            db.SaveChanges();

            return Ok(nhaCungCap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhaCungCapExists(int id)
        {
            return db.NhaCungCaps.Count(e => e.IDNhaCungCap == id) > 0;
        }
    }
}