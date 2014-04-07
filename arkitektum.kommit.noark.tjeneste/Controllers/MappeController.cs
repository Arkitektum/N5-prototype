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
    public class MappeController : ApiController
    {
        //private tjenesteContext db = new tjenesteContext();

       
        // GET api/Mappe
        public IEnumerable<MappeType> GetMappes()
        {
            var url = HttpContext.Current.Request.Url;
            var baseUri =
                new UriBuilder(
                    url.Scheme,
                    url.Host,
                    url.Port).Uri;

            //Rettinghetsstyring...og alle andre restriksjoner
            List<MappeType> testdata = new List<MappeType>();
            MappeType m = new MappeType();
            m.tittel = "testmappe";
            m.systemID = "12345";
            m.opprettetDato = DateTime.Now;

            List<LinkType> linker = new List<LinkType>();
            LinkType l = new LinkType();
            l.uri = baseUri + "api/Mappe/" + m.systemID;
            l.rel = "self";
            linker.Add(l);
            LinkType l2 = new LinkType();
            l2.uri = baseUri + "api/Arkivdel/" + "35212";
            l2.rel = "http://rel.kommit.no/noark5/v4/referanseArkivdel";
            linker.Add(l2);
            LinkType l3 = new LinkType();
            l3.uri = baseUri + "api/Mappe/" + m.systemID + "/registrering";
            l3.rel = "http://rel.kommit.no/noark5/v4/registrering";
            linker.Add(l3);

            LinkType l4 = new LinkType();
            l4.uri = baseUri + "api/Mappe/" + m.systemID + "/undermappe";
            l4.rel = "http://rel.kommit.no/noark5/v4/undermappe";
            linker.Add(l4);

            m.linker = linker.ToArray();

            testdata.Add(m);

            MappeType m2 = new MappeType();
            m2.tittel = "testmappe 2";
            m2.systemID = "234";
            m2.opprettetDato = DateTime.Now;

            List<LinkType> linker2 = new List<LinkType>();
            
            LinkType ml = new LinkType();
            ml.uri = baseUri + "api/Mappe/" + m2.systemID;
            ml.rel = "self";
            linker2.Add(ml);
            LinkType ml2 = new LinkType();
            ml2.uri = baseUri + "api/Arkivdel/21233";
            ml2.rel = "http://rel.kommit.no/noark5/v4/referanseArkivdel";
            linker2.Add(ml2);
            LinkType ml3 = new LinkType();
            ml3.uri = baseUri + "api/Mappe/" + m2.systemID + "/registrering";
            ml3.rel = "http://rel.kommit.no/noark5/v4/registrering";
            linker2.Add(ml3);

            LinkType ml4 = new LinkType();
            ml4.uri = baseUri + "api/Mappe/" + m2.systemID + "/undermappe";
            ml4.rel = "http://rel.kommit.no/noark5/v4/undermappe";
            linker2.Add(ml4);

            m2.linker = linker2.ToArray();

            testdata.Add(m2);

            return testdata.AsEnumerable();
        }

        //[Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<MappeType> Arkivdel(string id)
        {
            return GetMappes();
        }

        // GET api/Mappe/5
        public MappeType GetMappe(string id)
        {
            var url = HttpContext.Current.Request.Url;
            var baseUri =
                new UriBuilder(
                    url.Scheme,
                    url.Host,
                    url.Port).Uri;

           
            MappeType m = new MappeType();
            m.tittel = "testmappe";
            m.systemID = id;
            m.opprettetDato = DateTime.Now;

            List<LinkType> linker = new List<LinkType>();
            LinkType l = new LinkType();
            l.uri = baseUri + "api/Mappe/" + m.systemID;
            l.rel = "self";
            linker.Add(l);
            LinkType l2 = new LinkType();
            l2.uri = baseUri + "api/Arkivdel/12345";
            l2.rel = "http://rel.kommit.no/noark5/v4/referanseArkivdel";
            linker.Add(l2);
            LinkType l3 = new LinkType();
            l3.uri = baseUri + "api/Mappe/" + m.systemID + "/registrering";
            l3.rel = "http://rel.kommit.no/noark5/v4/registrering";
            linker.Add(l3);

            LinkType l4 = new LinkType();
            l4.uri = baseUri + "api/Mappe/" + m.systemID + "/undermappe";
            l4.rel = "http://rel.kommit.no/noark5/v4/undermappe";
            linker.Add(l4);

            m.linker = linker.ToArray();
            if (m == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return m;
        }

        //// PUT api/Mappe/5
        //public HttpResponseMessage PutMappe(string id, Mappe mappe)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != mappe.systemID)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    //TODO restriksjoner

        //    db.Entry(mappe).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //// POST api/Mappe
        //public HttpResponseMessage PostMappe(Mappe mappe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Mappes.Add(mappe);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mappe);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mappe.systemID }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //// DELETE api/Mappe/5
        //public HttpResponseMessage DeleteMappe(string id)
        //{
        //    Mappe mappe = db.Mappes.Find(id);
        //    if (mappe == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Mappes.Remove(mappe);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, mappe);
        //}

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}