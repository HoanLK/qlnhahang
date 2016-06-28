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
    public class DinhLuongAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/DinhLuongAPI
        public IQueryable<DinhLuong> GetDinhLuongs()
        {
            return db.DinhLuongs;
        }

        // GET: api/DinhLuongAPI/5
        [ResponseType(typeof(DinhLuong))]
        public IHttpActionResult GetDinhLuong(int id)
        {
            DinhLuong dinhLuong = db.DinhLuongs.Find(id);
            if (dinhLuong == null)
            {
                return NotFound();
            }

            return Ok(dinhLuong);
        }

        // PUT: api/DinhLuongAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDinhLuong(int id, DinhLuong dinhLuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dinhLuong.IDDinhLuong)
            {
                return BadRequest();
            }

            db.Entry(dinhLuong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DinhLuongExists(id))
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

        // POST: api/DinhLuongAPI
        [ResponseType(typeof(DinhLuong))]
        public IHttpActionResult PostDinhLuong(DinhLuong dinhLuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DinhLuongs.Add(dinhLuong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dinhLuong.IDDinhLuong }, dinhLuong);
        }

        // DELETE: api/DinhLuongAPI/5
        [ResponseType(typeof(DinhLuong))]
        public IHttpActionResult DeleteDinhLuong(int id)
        {
            DinhLuong dinhLuong = db.DinhLuongs.Find(id);
            if (dinhLuong == null)
            {
                return NotFound();
            }

            db.DinhLuongs.Remove(dinhLuong);
            db.SaveChanges();

            return Ok(dinhLuong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DinhLuongExists(int id)
        {
            return db.DinhLuongs.Count(e => e.IDDinhLuong == id) > 0;
        }
    }
}