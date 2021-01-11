using ProductShop.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportUsersWithSoldProductsDTO_P08
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }

        [XmlArray("SoldProducts")]
        public List<ExportSoldProductsDTO> SoldProducts { get; set; }
    }
}

//<User>
//      <firstName>Cathee</firstName>
//      <lastName>Rallings</lastName>
//      <age>33</age>
//      <SoldProducts>
//        <count>9</count>
//        <products>
//          <Product>
//            <name>Fair Foundation SPF 15</name>
//            <price>1394.24</price>
//          </Product>
//          <Product>
//            <name>IOPE RETIGEN MOISTURE TWIN CAKE NO.21</name>
//            <price>1257.71</price>
//          </Product>
//          <Product>
//            <name>ESIKA</name>
//            <price>879.37</price>
//          </Product>
//          <Product>
//            <name>allergy eye</name>
//            <price>426.91</price>
//          </Product>
