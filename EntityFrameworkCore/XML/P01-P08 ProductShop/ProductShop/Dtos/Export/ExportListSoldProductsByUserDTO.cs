using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")] //------------------------------------------------------
    class ExportListSoldProductsByUserDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<ExportProductsSoldByUserDTO> ListProducts { get; set; }
    }
}


      //<SoldProducts>
      //  <count>9</count>
      //  <products>
      //    <Product>
      //      <name>Fair Foundation SPF 15</name>
      //      <price>1394.24</price>
      //    </Product>
      //    <Product>
      //      <name>IOPE RETIGEN MOISTURE TWIN CAKE NO.21</name>
      //      <price>1257.71</price>
      //    </Product>
      //    <Product>
      //      <name>ESIKA</name>
      //      <price>879.37</price>
      //    </Product>
      //    <Product>
      //      <name>allergy eye</name>
      //      <price>426.91</price>
      //    </Product>

