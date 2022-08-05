using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class GunXmlExportModel
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")]
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public string GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public string BarrelLength { get; set; }

        [XmlAttribute("Range")]
        public string Range { get; set; }

        [XmlArray("Countries")]
        public CountryXmlExportModel[] Countries { get; set; }
    }

    [XmlType("Country")]
    public class CountryXmlExportModel
    {
        [XmlAttribute("Country")]
        public string Country { get; set; }

        [XmlAttribute("ArmySize")]
        public string ArmySize { get; set; }
    }
}

//< Gun Manufacturer = "Krupp" GunType = "Mortar" GunWeight = "1291272" BarrelLength = "8.31" Range = "14258" >
//    < Countries >
//      < Country Country = "Sweden" ArmySize = "5437337" />
//      < Country Country = "Portugal" ArmySize = "9523599" />
//    </ Countries >
//  </ Gun >
