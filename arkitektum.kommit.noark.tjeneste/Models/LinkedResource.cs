using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace arkitektum.kommit.noark.tjeneste
{
    public abstract class LinkedResource
    {
        public LinkedResource()
        {
            this.Links = new List<Link>();
        }

        public List<Link> Links { get; private set; }

        public string href { get; set; }

    }
}