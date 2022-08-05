using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ShellXmlImportModel
    {
        [Range(2, 1_680)]
        public double ShellWeight { get; set; }

        [Required]
        [StringLength(30), MinLength(4)]
        public string Caliber { get; set; }
    }
}

//< Shell >
//    < ShellWeight > 50 </ ShellWeight >
//    < Caliber > 155 mm(6.1 in) </ Caliber >
//  </ Shell >