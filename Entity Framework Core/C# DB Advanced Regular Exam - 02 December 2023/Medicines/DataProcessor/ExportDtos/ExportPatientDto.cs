using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Patient")]
    public class ExportPatientDto
    {
        [XmlAttribute]
        public string Gender { get; set; }
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public string AgeGroup { get; set; }
        [XmlArray]
        public MedicineDto[] Medicines { get; set; }
    }

    [XmlType("Medicine")]
    public class MedicineDto
    {
        [XmlAttribute]
        public string Category { get; set; }
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public string Price { get; set; }
        [XmlElement]
        public string Producer { get; set; }
        [XmlElement]
        public string BestBefore { get; set; }
    }
}
