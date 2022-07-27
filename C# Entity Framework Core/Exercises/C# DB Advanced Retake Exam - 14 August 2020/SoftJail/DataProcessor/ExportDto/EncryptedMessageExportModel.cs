using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class EncryptedMessageExportModel
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}

//< Prisoner >
//    < Id > 3 </ Id >
//    < Name > Binni Cornhill </ Name >
//    < IncarcerationDate > 1967 - 04 - 29 </ IncarcerationDate >
//    < EncryptedMessages >
//      < Message >
//        < Description > !? sdnasuoht evif - ytnewt rof deksa uoy ro orez artxe na ereht sI</Description>
//      </Message>
//    </EncryptedMessages>
//  </Prisoner>
