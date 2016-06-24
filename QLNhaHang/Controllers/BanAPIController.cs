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
    public class BanAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/BanAPI
        public IQueryable<Ban> GetBans()
        {
            return db.Bans;
        }

        // GET: api/BanAPI/5
        [ResponseType(typeof(Ban))]
        public IHttpActionResult GetBan(int id)
        {
            Ban ban = db.Bans.Find(id);
            if (ban == null)
            {
                return NotFound();
            }

            return Ok(ban);
        }

        // PUT: api/BanAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBan(int id, Ban ban)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ban.IDBan)
            {
                return BadRequest();
            }

            db.Entry(ban).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanExists(id))
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

        // POST: api/BanAPI
        [ResponseType(typeof(Ban))]
        public IHttpActionResult PostBan(Ban ban)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bans.Add(ban);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ban.IDBan }, ban);
        }

        // DELETE: api/BanAPI/5
        [ResponseType(typeof(Ban))]
        public IHttpActionResult DeleteBan(int id)
        {
            Ban ban = db.Bans.Find(id);
            if (ban == null)
            {
                return NotFound();
            }

            db.Bans.Remove(ban);
            db.SaveChanges();

            return Ok(ban);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BanExists(int id)
        {
            return db.Bans.Count(e => e.IDBan == id) > 0;
        }
    }
}