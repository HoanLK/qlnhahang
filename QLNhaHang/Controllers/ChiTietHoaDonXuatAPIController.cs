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
    public class ChiTietHoaDonXuatAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/ChiTietHoaDonXuatAPI
        public IQueryable<ChiTietHoaDonXuat> GetChiTietHoaDonXuats()
        {
            return db.ChiTietHoaDonXuats;
        }

        // GET: api/ChiTietHoaDonXuatAPI/5
        [ResponseType(typeof(ChiTietHoaDonXuat))]
        public IHttpActionResult GetChiTietHoaDonXuat(int id)
        {
            ChiTietHoaDonXuat chiTietHoaDonXuat = db.ChiTietHoaDonXuats.Find(id);
            if (chiTietHoaDonXuat == null)
            {
                return NotFound();
            }

            return Ok(chiTietHoaDonXuat);
        }

        // PUT: api/ChiTietHoaDonXuatAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietHoaDonXuat(int id, ChiTietHoaDonXuat chiTietHoaDonXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietHoaDonXuat.IDChiTietHoaDonXuat)
            {
                return BadRequest();
            }

            db.Entry(chiTietHoaDonXuat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHoaDonXuatExists(id))
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

        // POST: api/ChiTietHoaDonXuatAPI
        [ResponseType(typeof(ChiTietHoaDonXuat))]
        public IHttpActionResult PostChiTietHoaDonXuat(ChiTietHoaDonXuat chiTietHoaDonXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietHoaDonXuats.Add(chiTietHoaDonXuat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chiTietHoaDonXuat.IDChiTietHoaDonXuat }, chiTietHoaDonXuat);
        }

        // DELETE: api/ChiTietHoaDonXuatAPI/5
        [ResponseType(typeof(ChiTietHoaDonXuat))]
        public IHttpActionResult DeleteChiTietHoaDonXuat(int id)
        {
            ChiTietHoaDonXuat chiTietHoaDonXuat = db.ChiTietHoaDonXuats.Find(id);
            if (chiTietHoaDonXuat == null)
            {
                return NotFound();
            }

            db.ChiTietHoaDonXuats.Remove(chiTietHoaDonXuat);
            db.SaveChanges();

            return Ok(chiTietHoaDonXuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietHoaDonXuatExists(int id)
        {
            return db.ChiTietHoaDonXuats.Count(e => e.IDChiTietHoaDonXuat == id) > 0;
        }
    }
}