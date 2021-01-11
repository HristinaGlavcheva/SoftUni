using CarDealer.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("Car")]
    public class ImportCarsDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public List<ImportPartCarDTO> Parts { get; set; }
    }
}

//<Cars>
//  <Car>
//    <make>Opel</make>
//    <model>Omega</model>
//    <TraveledDistance>176664996</TraveledDistance>
//    <parts>
//      <partId id = "38" />
//      < partId id="102"/>
//      <partId id = "23" />
//      < partId id="116"/>
//      <partId id = "46" />
//      < partId id="68"/>
//      <partId id = "88" />
//      < partId id="104"/>
//      <partId id = "71" />
//      < partId id="32"/>
//      <partId id = "114" />
//    </ parts >
//  </ Car >
//  < Car >
//    < make > Opel </ make >
//    < model > Astra </ model >
//    < TraveledDistance > 516628215 </ TraveledDistance >
//    < parts >
//      < partId id="39"/>
//      <partId id = "62" />
//      < partId id="72"/>
//    </parts>
//  </Car>
