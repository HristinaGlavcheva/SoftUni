using System.Xml.Serialization;

namespace ProductShop.Datasets
{
    [XmlType ("CategoryProduct")]
    public class ImportCategories_ProductsDTO
    {
        [XmlElement ("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement ("ProductId")]
        public int ProductId { get; set; }
    }
}
