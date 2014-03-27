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
    public class ArkivController : ApiController
    {
        private tjenesteContext db = new tjenesteContext();

        // GET api/Arkiv
        public IEnumerable<Arkiv> GetArkivs()
        {
            return db.Arkivs.AsEnumerable();
        }

        // GET api/Arkiv/5
        public Arkiv GetArkiv(string id)
        {
            Arkiv arkiv = db.Arkivs.Find(id);
            if (arkiv == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return arkiv;
        }

        // PUT api/Arkiv/5
        public HttpResponseMessage PutArkiv(string id, Arkiv arkiv)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != arkiv.systemID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(arkiv).State = EntityState.Modified;

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

        // POST api/Arkiv
        public HttpResponseMessage PostArkiv(Arkiv arkiv)
        {
            if (ModelState.IsValid)
            {
                db.Arkivs.Add(arkiv);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, arkiv);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = arkiv.systemID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Arkiv/5
        public HttpResponseMessage DeleteArkiv(string id)
        {
            Arkiv arkiv = db.Arkivs.Find(id);
            if (arkiv == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Arkivs.Remove(arkiv);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, arkiv);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}