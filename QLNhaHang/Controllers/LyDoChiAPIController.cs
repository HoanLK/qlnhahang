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
    public class LyDoChiAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/LyDoChiAPI
        public IQueryable<LyDoChi> GetLyDoChis()
        {
            return db.LyDoChis;
        }

        // GET: api/LyDoChiAPI/5
        [ResponseType(typeof(LyDoChi))]
        public IHttpActionResult GetLyDoChi(string id)
        {
            LyDoChi lyDoChi = db.LyDoChis.Find(id);
            if (lyDoChi == null)
            {
                return NotFound();
            }

            return Ok(lyDoChi);
        }

        // PUT: api/LyDoChiAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLyDoChi(string id, LyDoChi lyDoChi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lyDoChi.IDLyDoChi)
            {
                return BadRequest();
            }

            db.Entry(lyDoChi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LyDoChiExists(id))
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

        // POST: api/LyDoChiAPI
        [ResponseType(typeof(LyDoChi))]
        public IHttpActionResult PostLyDoChi(LyDoChi lyDoChi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LyDoChis.Add(lyDoChi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LyDoChiExists(lyDoChi.IDLyDoChi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lyDoChi.IDLyDoChi }, lyDoChi);
        }

        // DELETE: api/LyDoChiAPI/5
        [ResponseType(typeof(LyDoChi))]
        public IHttpActionResult DeleteLyDoChi(string id)
        {
            LyDoChi lyDoChi = db.LyDoChis.Find(id);
            if (lyDoChi == null)
            {
                return NotFound();
            }

            db.LyDoChis.Remove(lyDoChi);
            db.SaveChanges();

            return Ok(lyDoChi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LyDoChiExists(string id)
        {
            return db.LyDoChis.Count(e => e.IDLyDoChi == id) > 0;
        }
    }
}