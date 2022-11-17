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
using NavTechOrderProject.Models;

namespace NavTechOrderProject.Controllers
{
    public class CustomerTablesController : ApiController
    {
        private NavTechProjectEntities db = new NavTechProjectEntities();

        // GET: api/CustomerTables
        public IQueryable<CustomerTable> GetCustomerTables()
        {
            return db.CustomerTables;
        }

        // GET: api/CustomerTables/5
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult GetCustomerTable(long id)
        {
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return NotFound();
            }

            return Ok(customerTable);
        }

        // PUT: api/CustomerTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerTable(long id, CustomerTable customerTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerTable.CustomerId)
            {
                return BadRequest();
            }

            db.Entry(customerTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTableExists(id))
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

        // POST: api/CustomerTables
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult PostCustomerTable(CustomerTable customerTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerTables.Add(customerTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerTable.CustomerId }, customerTable);
        }

        // DELETE: api/CustomerTables/5
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult DeleteCustomerTable(long id)
        {
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return NotFound();
            }

            db.CustomerTables.Remove(customerTable);
            db.SaveChanges();

            return Ok(customerTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerTableExists(long id)
        {
            return db.CustomerTables.Count(e => e.CustomerId == id) > 0;
        }
    }
}