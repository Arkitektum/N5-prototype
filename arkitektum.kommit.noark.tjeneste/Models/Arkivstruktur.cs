using arkitektum.kommit.noark.tjeneste.Models.BevaringOgKassasjon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace arkitektum.kommit.noark.tjeneste.Models.Arkivstruktur
{
  

    //[DataContract(Namespace = "http://www.arkivverket.no/standarder/noark5/v4.0/")]
    /// <summary>
    /// Arkiv er det øverste nivået i arkivstrukturen. De fleste brukere vil bare ha behov for å opprette 
    ///ett arkiv i sin Noark 5-løsning. Men det skal være mulig å opprette flere arkiver. Det kan være 
    ///aktuelt dersom flere organer deler samme løsning. Det kan også være aktuelt dersom en hel 
    ///etat deler samme løsning. Her kan da f.eks. hovedkontoret og hvert distriktskontor settes opp 
    ///med hvert sitt arkiv. Men ved elektronisk arkivering er det heller ikke noe i veien for at hele 
    ///etaten deler samme arkiv, selv om de enkelte avdelinger er spredt over et stort geografisk 
    ///område. 
    ///
    ///Arkiv er obligatorisk i et arkivuttrekk. Toppnivået skal bare ha én forekomst, men kan ha ett 
    ///eller flere undernivåer, se om underarkiv nedenfor. Et arkiv skal inneholde en eller flere 
    ///arkivdeler. Dersom arkivet består av underarkiver, skal arkivdel være knyttet til det laveste 
    ///nivået av disse.
    /// </summary>
    public class Arkiv : Arkivenhet
    {
        /// <summary>
        /// 
        /// </summary>
        public string tittel { get; set; }
        public string beskrivelse { get; set; }
        public string arkivstatus { get; set; }
        public string dokumentmedium { get; set; }
        public string oppbevaringssted { get; set; }
        public DateTime opprettetDato { get; set; }
        public string opprettetAv { get; set; }
        public DateTime avsluttetDato { get; set; }
        public string avsluttetAv { get; set; }
        public List<Arkivskaper> arkivskaper { get; set; }
        //public List<Arkiv> underarkiv { get; set; }
 
        public ICollection<Arkivdel> arkivdel { get; set; }
        public string self { get; set; } 

    }

    public class Arkivdel : Arkivenhet
    {
        public string tittel { get; set; }
        public string beskrivelse { get; set; }
        public string arkivdelstatus { get; set; }
        public string dokumentmedium { get; set; }
        public string oppbevaringssted { get; set; }
        public DateTime opprettetDato { get; set; }
        public string opprettetAv { get; set; }
        public DateTime avsluttetDato { get; set; }
        public string avsluttetAv { get; set; }
        public DateTime arkivperiodeStartDato { get; set; }
        public DateTime arkivperiodeSluttDato { get; set; }
        public string referanseForløper { get; set; }
        public string referanseArvtaker { get; set; }
        public Kassasjon kassasjon { get; set; }
        public UtførtKassasjon utførtKassasjon { get; set; }
        public Sletting sletting { get; set; }
        public Skjerming skjerming { get; set; }
        public Gradering gradering { get; set; }
        public List<Klassifikasjonssystem> klassifikasjonssystem { get; set; }
        public List<Mappe> mappe { get; set; }
        public List<Registrering> registrering { get; set; }
    }

    public class Arkivenhet
    {
        [Key]
        public string systemID { get; set; }
    }

    
    /// <summary>
    /// Tradisjonelt har et arkiv blitt definert etter organisasjon. Ett organ skaper ett arkiv, dvs. 
    ///organet er arkivskaperen. Men elektronisk informasjonsteknologi har ført til at det blir stadig 
    ///vanligere at flere arkivskapere sammen skaper ett arkiv. Arkivet vil da være definert etter 
    ///funksjon, ikke organisasjon3
    ///. 
    ///
    ///I en Noark 5-løsning skal det altså være mulig å knytte en eller flere arkivskapere til ett arkiv. 
    ///Informasjon om arkivskapere er obligatorisk i arkivuttrekk. 
    /// </summary>
    public class Arkivskaper : Arkivenhet
    {
        public string arkivskaperID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string arkivskaperNavn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string beskrivelse { get; set; }
    }

    public class Basisregistrering : Registrering
    {
        public string registreringsID { get; set; }
        public string tittel { get; set; }
        public string offentligTittel { get; set; }
        public string beskrivelse { get; set; }
        public string nøkkelord { get; set; }
        public string forfatter { get; set; }
        public string dokumentmedium { get; set; }
        public string oppbevaringssted { get; set; }
    }

    public class Dokumentbeskrivelse : Arkivenhet
    {
        public string dokumenttype { get; set; }
        public string dokumentstatus { get; set; }
        public string tittel { get; set; }
        public string beskrivelse { get; set; }
        public string forfatter { get; set; }
        public string opprettetAv { get; set; }
        public DateTime opprettetDato { get; set; }
        public string dokumentmedium { get; set; }
        public string oppbevaringssted { get; set; }
        public string tilknyttetRegistreringSom { get; set; }
        public int dokumentnummer { get; set; }
        public DateTime tilknyttetDato { get; set; }
        public string tilknyttetAv { get; set; }
        public Kassasjon kassasjon { get; set; }
        public UtførtKassasjon utførtKassasjon { get; set; }
        public Sletting sletting { get; set; }
        public Skjerming skjerming { get; set; }
        public Gradering gradering { get; set; }
        public ElektroniskSignatur elektroniskSignatur { get; set; }
        public List<Dokumentobjekt> dokumentobjekt { get; set; }
    }

    public class Dokumentobjekt
    {
        [Key]
        public string systemID { get; set; }
        public int versjonsnummer { get; set; }
        public string variantformat { get; set; }
        public string format { get; set; }
        public string formatDetaljer { get; set; }
        public DateTime opprettetDato { get; set; }
        public string opprettetAv { get; set; }
        public string referanseDokumentfil { get; set; }
        public string sjekksum { get; set; }
        public string sjekksumAlgoritme { get; set; }
        public string filstørrelse { get; set; }
        public ElektroniskSignatur elektroniskSignatur { get; set; }
        public List<Konvertering> konvertering { get; set; }
    }

    public class ElektroniskSignatur
    {
        public string elektroniskSignaturSikkerhetsnivå { get; set; }
        public string elektroniskSignaturVerifisert { get; set; }
        public DateTime verifisertDato { get; set; }
        public string verifisertAv { get; set; }
    }

    public class Klasse : Arkivenhet
    {
        public string klasseID { get; set; }
        public string tittel { get; set; }
        public string beskrivelse { get; set; }
        public string nøkkelord { get; set; }
        public DateTime opprettetDato { get; set; }
        public string opprettetAv { get; set; }
        public DateTime avsluttetDato { get; set; }
        public string avsluttetAv { get; set; }
        public Skjerming skjerming { get; set; }
        public Kassasjon kassasjon { get; set; }
    }

    public class Klassifikasjonssystem : Arkivenhet
    {
        public string klassifikasjonstype { get; set; }
        public string tittel { get; set; }
        public string beskrivelse { get; set; }
        public DateTime opprettetDato { get; set; }
        public string opprettetAv { get; set; }
        public DateTime avsluttetDato { get; set; }
        public string avsluttetAv { get; set; }
    }

    public class Konvertering
    {
        [Key]
        public string systemID { get; set; }
        public DateTime konvertertDato { get; set; }
        public string konvertertAv { get; set; }
        public string konvertertFraFormat { get; set; }
        public string konvertertTilFormat { get; set; }
        public string konverteringsverktøy { get; set; }
        public string konverteringskommentar { get; set; }
    }

    public class Kryssreferanse
    {
    }

    public class Mappe : Arkivenhet
    {
        public string mappeID { get; set; }
        public string tittel { get; set; }
        public string offentligTittel { get; set; }
        public string beskrivelse { get; set; }
        public List<string> nøkkelord { get; set; }
        public string dokumentmedium { get; set; }
        public List<string> oppbevaringssted { get; set; }
        public DateTime opprettetDato { get; set; }
        public string opprettetAv { get; set; }
        public DateTime avsluttetDato { get; set; }
        public string avsluttetAv { get; set; }
        public Kassasjon kassasjon { get; set; }
        public Skjerming skjerming { get; set; }
        public Gradering gradering { get; set; }
        public List<string> referanseArkivdel { get; set; }
        public string referanseForelderMappe { get; set; }
        public List<Registrering> registrering { get; set; }
        public List<Merknad> merknad { get; set; }
        public List<Kryssreferanse> kryssreferanse { get; set; }
        //undermapper
    }

    public class Merknad
    {
        [Key]
        public string systemID { get; set; }
        public string merknadstekst { get; set; }
        public string merknadstype { get; set; }
        public DateTime merknadsdato { get; set; }
        public string merknadRegistrertAv { get; set; }
    }

    public class Registrering : Arkivenhet
    {
        public string opprettetAv { get; set; }
        public DateTime opprettetDato { get; set; }
        public DateTime arkivertDato { get; set; }
        public string arkivertAv { get; set; }
        public Kassasjon kassasjon { get; set; }
        public Skjerming skjerming { get; set; }
        public Gradering gradering { get; set; }
        public string referanseArkivdel { get; set; }
        public List<Dokumentbeskrivelse> dokumentbeskrivelse { get; set; }
        public List<Dokumentobjekt> dokumentobjekt { get; set; }
    }


}