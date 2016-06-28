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
    public class ChiTietHoaDonBanHangAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/ChiTietHoaDonBanHangAPI
        public IQueryable<ChiTietHoaDonBanHang> GetChiTietHoaDonBanHangs()
        {
            return db.ChiTietHoaDonBanHangs;
        }

        // GET: api/ChiTietHoaDonBanHangAPI/5
        [ResponseType(typeof(ChiTietHoaDonBanHang))]
        public IHttpActionResult GetChiTietHoaDonBanHang(int id)
        {
            ChiTietHoaDonBanHang chiTietHoaDonBanHang = db.ChiTietHoaDonBanHangs.Find(id);
            if (chiTietHoaDonBanHang == null)
            {
                return NotFound();
            }

            return Ok(chiTietHoaDonBanHang);
        }

        // PUT: api/ChiTietHoaDonBanHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietHoaDonBanHang(int id, ChiTietHoaDonBanHang chiTietHoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietHoaDonBanHang.IDChiTietHoaDonBanHang)
            {
                return BadRequest();
            }

            db.Entry(chiTietHoaDonBanHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHoaDonBanHangExists(id))
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

        // POST: api/ChiTietHoaDonBanHangAPI
        [ResponseType(typeof(ChiTietHoaDonBanHang))]
        public IHttpActionResult PostChiTietHoaDonBanHang(ChiTietHoaDonBanHang chiTietHoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietHoaDonBanHangs.Add(chiTietHoaDonBanHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chiTietHoaDonBanHang.IDChiTietHoaDonBanHang }, chiTietHoaDonBanHang);
        }

        // DELETE: api/ChiTietHoaDonBanHangAPI/5
        [ResponseType(typeof(ChiTietHoaDonBanHang))]
        public IHttpActionResult DeleteChiTietHoaDonBanHang(int id)
        {
            ChiTietHoaDonBanHang chiTietHoaDonBanHang = db.ChiTietHoaDonBanHangs.Find(id);
            if (chiTietHoaDonBanHang == null)
            {
                return NotFound();
            }

            db.ChiTietHoaDonBanHangs.Remove(chiTietHoaDonBanHang);
            db.SaveChanges();

            return Ok(chiTietHoaDonBanHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietHoaDonBanHangExists(int id)
        {
            return db.ChiTietHoaDonBanHangs.Count(e => e.IDChiTietHoaDonBanHang == id) > 0;
        }
    }
}