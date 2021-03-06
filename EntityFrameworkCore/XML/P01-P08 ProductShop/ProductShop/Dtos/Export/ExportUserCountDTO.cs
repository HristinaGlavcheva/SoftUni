﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    //[XmlType("Users")]
    public class ExportUserCountDTO
    {
        [XmlElement("count")]
        public int Count { get; set; } 

        [XmlArray("users")]
        public ExportUserDTO[] Users { get; set; }
    }

    [XmlType("User")]
    public class ExportUserDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportProductCountDTO SoldProducts { get; set; }
    }

    //[XmlType("SoldProducts")] //------------------------------------------------------
    public class ExportProductCountDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportProductDTO[] Products { get; set; }
    }

    [XmlType("Product")]
    public class ExportProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}

//<Users>
//  <count>54</count>
//  <users>
//    <User>
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
//...
//</Users>
