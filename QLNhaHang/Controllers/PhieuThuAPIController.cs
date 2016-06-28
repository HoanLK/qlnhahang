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
    public class PhieuThuAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/PhieuThuAPI
        public IQueryable<PhieuThu> GetPhieuThus()
        {
            return db.PhieuThus;
        }

        // GET: api/PhieuThuAPI/5
        [ResponseType(typeof(PhieuThu))]
        public IHttpActionResult GetPhieuThu(int id)
        {
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            if (phieuThu == null)
            {
                return NotFound();
            }

            return Ok(phieuThu);
        }

        // PUT: api/PhieuThuAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhieuThu(int id, PhieuThu phieuThu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieuThu.IDPhieuThu)
            {
                return BadRequest();
            }

            db.Entry(phieuThu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuThuExists(id))
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

        // POST: api/PhieuThuAPI
        [ResponseType(typeof(PhieuThu))]
        public IHttpActionResult PostPhieuThu(PhieuThu phieuThu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhieuThus.Add(phieuThu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phieuThu.IDPhieuThu }, phieuThu);
        }

        // DELETE: api/PhieuThuAPI/5
        [ResponseType(typeof(PhieuThu))]
        public IHttpActionResult DeletePhieuThu(int id)
        {
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            if (phieuThu == null)
            {
                return NotFound();
            }

            db.PhieuThus.Remove(phieuThu);
            db.SaveChanges();

            return Ok(phieuThu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhieuThuExists(int id)
        {
            return db.PhieuThus.Count(e => e.IDPhieuThu == id) > 0;
        }
    }
}