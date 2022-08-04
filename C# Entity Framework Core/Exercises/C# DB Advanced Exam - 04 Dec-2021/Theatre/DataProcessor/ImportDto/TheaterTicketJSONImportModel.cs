using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class TheaterTicketJSONImportModel
    {
        [Required]
        [StringLength(30), MinLength(4)]
        public string Name { get; set; }

        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30), MinLength(4)]
        public string Director { get; set; }

        public ICollection<TicketJSONImportModel> Tickets { get; set; }
    }

    public class TicketJSONImportModel
    {
        [Range(typeof(decimal), "1" , "100")]
        public decimal Price { get; set; }

        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }
    }
}

//"Name": "Corona Theatre",
//    "NumberOfHalls": 7,
//    "Director": "Alwin MacCosty",
//    "Tickets": [
//      {
//        "Price": 7.63,
//        "RowNumber": -5,
//        "PlayId": 4
//      },
//      {
//    "Price": 47.96,
//        "RowNumber": 9,
//        "PlayId": 3
//      },
//      ….
//    ]