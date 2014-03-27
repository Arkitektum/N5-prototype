using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using arkitektum.kommit.noark.tjeneste.Models.Arkivstruktur;
using arkitektum.kommit.noark.tjeneste.Models.arkitektum.kommit.noark;

namespace arkitektum.kommit.noark.tjeneste.Controllers
{
    public class ArkivdelController : ApiController
    {
        private tjenesteContext db = new tjenesteContext();

        // GET api/Arkivdel
        public IEnumerable<Arkivdel> GetArkivdels()
        {
            
            return db.Arkivdels.AsEnumerable();
        }

        // GET api/Arkivdel/5
        public Arkivdel GetArkivdel(string id)
        {
            Arkivdel arkivdel = db.Arkivdels.Find(id);
            if (arkivdel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return arkivdel;
        }

        // PUT api/Arkivdel/5
        public HttpResponseMessage PutArkivdel(string id, Arkivdel arkivdel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != arkivdel.systemID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(arkivdel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Arkivdel
        public HttpResponseMessage PostArkivdel(Arkivdel arkivdel)
        {
            if (ModelState.IsValid)
            {
                db.Arkivdels.Add(arkivdel);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, arkivdel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = arkivdel.systemID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Arkivdel/5
        public HttpResponseMessage DeleteArkivdel(string id)
        {
            Arkivdel arkivdel = db.Arkivdels.Find(id);
            if (arkivdel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Arkivdels.Remove(arkivdel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, arkivdel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}