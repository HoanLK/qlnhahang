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
    public class LyDoThuAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/LyDoThuAPI
        public IQueryable<LyDoThu> GetLyDoThus()
        {
            return db.LyDoThus;
        }

        // GET: api/LyDoThuAPI/5
        [ResponseType(typeof(LyDoThu))]
        public IHttpActionResult GetLyDoThu(int id)
        {
            LyDoThu lyDoThu = db.LyDoThus.Find(id);
            if (lyDoThu == null)
            {
                return NotFound();
            }

            return Ok(lyDoThu);
        }

        // PUT: api/LyDoThuAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLyDoThu(int id, LyDoThu lyDoThu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lyDoThu.IDLyDoThu)
            {
                return BadRequest();
            }

            db.Entry(lyDoThu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LyDoThuExists(id))
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

        // POST: api/LyDoThuAPI
        [ResponseType(typeof(LyDoThu))]
        public IHttpActionResult PostLyDoThu(LyDoThu lyDoThu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LyDoThus.Add(lyDoThu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lyDoThu.IDLyDoThu }, lyDoThu);
        }

        // DELETE: api/LyDoThuAPI/5
        [ResponseType(typeof(LyDoThu))]
        public IHttpActionResult DeleteLyDoThu(int id)
        {
            LyDoThu lyDoThu = db.LyDoThus.Find(id);
            if (lyDoThu == null)
            {
                return NotFound();
            }

            db.LyDoThus.Remove(lyDoThu);
            db.SaveChanges();

            return Ok(lyDoThu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LyDoThuExists(int id)
        {
            return db.LyDoThus.Count(e => e.IDLyDoThu == id) > 0;
        }
    }
}