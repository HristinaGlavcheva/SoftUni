﻿using System;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("Customer")]
    public class ImportCustomersDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
