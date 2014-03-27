using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace arkitektum.kommit.noark.tjeneste.Models.BevaringOgKassasjon
{
    public class Gradering
    {
        public string gradering { get; set; }
        public DateTime graderingsdato { get; set; }
        public string gradertAv { get; set; }
        public DateTime nedgraderingsdato { get; set; }
        public string nedgradertAv { get; set; }
    }

    public class Kassasjon
    {
        public string kassasjonsvedtak { get; set; }
        public string kassasjonshjemmel { get; set; }
        public int bevaringstid { get; set; }
        public DateTime kassasjonsdato { get; set; }
    }

    public class Skjerming
    {
        public string tilgangsrestriksjon { get; set; }
        public string skjermingshjemmel { get; set; }
        public string skjermingMetadata { get; set; }
        public string skjermingDokument { get; set; }
        public int skjermingsvarighet { get; set; }
        public DateTime skjermingOpphørerDato { get; set; }
    }

    public class Sletting
    {
        public string slettingstype { get; set; }
        public DateTime slettetDato { get; set; }
        public string slettetAv { get; set; }
    }

    public class UtførtKassasjon
    {
        public DateTime kassertDato { get; set; }
        public string kassertAv { get; set; }
    }


}