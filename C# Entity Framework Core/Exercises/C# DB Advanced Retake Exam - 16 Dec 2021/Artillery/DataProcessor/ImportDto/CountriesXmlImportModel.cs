using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class CountriesXmlImportModel
    {
        [Required]
        [StringLength(60), MinLength(4)]
        public string CountryName { get; set; }

        [Range(50_000, 10_000_000)]
        public int ArmySize { get; set; }
    }
}

//< Countries >
//  < Country >
//    < CountryName > Afghanistan </ CountryName >
//    < ArmySize > 1697064 </ ArmySize >
//  </ Country >
