using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayXMLImportModel
    {
        [Required]
        [StringLength(50), MinLength(4)]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        [Required]
        [StringLength(700)]
        public string Description { get; set; }

        [Required]
        [StringLength(30), MinLength(4)]
        public string Screenwriter { get; set; }
    }
}

//< Play >
//    < Title > The Hsdfoming </ Title >
//    < Duration > 03:40:00 </ Duration >
//    < Rating > 8.2 </ Rating >
//    < Genre > Action </ Genre >
//    < Description > A guyat Pinter turns into a debatable conundrum as oth ordinary and menacing. Much of this has to do with the fabled "Pinter Pause," which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.</Description>
//    <Screenwriter>Roger Nciotti</Screenwriter>
//  </Play>
