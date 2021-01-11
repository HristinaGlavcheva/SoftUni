using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType ("Category")]
    public class ExportCtegoriesByProductsDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}

//<? xml version="1.0" encoding="utf-16"?>
//<Categories>
//  <Category>
//    <name>Garden</name>
//    <count>23</count>
//    <averagePrice>709.94739130434782608695652174</averagePrice>
//    <totalRevenue>16328.79</totalRevenue>
//  </Category>
//  <Category>
//    <name>Adult</name>
//    <count>22</count>
//    <averagePrice>704.41</averagePrice>
//    <totalRevenue>15497.02</totalRevenue>
//  </Category>
//...
//</Categories>
