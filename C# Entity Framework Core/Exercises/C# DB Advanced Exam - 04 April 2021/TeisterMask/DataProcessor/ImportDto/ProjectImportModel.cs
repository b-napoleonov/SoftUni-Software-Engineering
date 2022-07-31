using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectImportModel
    {
        [Required]
        [StringLength(40), MinLength(2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TaskImportModel[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class TaskImportModel
    {
        [Required]
        [StringLength(40), MinLength(2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [EnumDataType(typeof(ExecutionType))]
        [XmlElement("ExecutionType")]
        public string ExecutionType { get; set; }

        [EnumDataType(typeof (LabelType))]
        [XmlElement("LabelType")]
        public string LabelType { get; set; }
    }
}
