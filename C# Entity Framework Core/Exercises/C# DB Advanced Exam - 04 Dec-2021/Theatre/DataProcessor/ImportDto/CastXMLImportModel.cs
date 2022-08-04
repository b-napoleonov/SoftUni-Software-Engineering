using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class CastXMLImportModel
    {
        [Required]
        [StringLength(30), MinLength(4)]
        public string FullName { get; set; }

        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(@"\+44-\d{2}-\d{3}-\d{4}")]
        public string PhoneNumber { get; set; }

        public int PlayId { get; set; }
    }
}

//< Cast >
//    < FullName > Van Tyson </ FullName >
//    < IsMainCharacter > false </ IsMainCharacter >
//    < PhoneNumber > +44 - 35 - 745 - 2774 </ PhoneNumber >
//    < PlayId > 26 </ PlayId >
//  </ Cast >