using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ManufacturerXmlImportModel
    {
        [Required]
        [StringLength(40), MinLength(4)]
        public string ManufacturerName { get; set; }

        [Required]
        [StringLength(100), MinLength(10)]
        public string Founded { get; set; }
    }
}

//< Manufacturer >
//    < ManufacturerName > BAE Systems </ ManufacturerName >
//    < Founded > 30 November 1999, London, England </ Founded >
//  </ Manufacturer >
