using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType(nameof(Creator))]
    public class ImportCtreatorDto
    {
        [MinLength(2)]
        [MaxLength(7)]
        [XmlElement(nameof(FirstName))]
        public string FirstName { get; set; } = null!;
        [MinLength(2)]
        [MaxLength(7)]
        [XmlElement(nameof(LastName))]
        public string LastName { get; set; } = null!;
        [XmlArray("Boardgames")]
        public BoardgameDto[] Boardgames { get; set; }
    }

    [XmlType(nameof(Boardgame))]
    public class BoardgameDto
    {
        [MinLength(10)]
        [MaxLength(20)]
        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;
        [Range(1, 10.00)]
        [XmlElement(nameof(Rating))]
        public double Rating { get; set; }
        [Range(2018, 2023)]
        [XmlElement(nameof(YearPublished))]
        public int YearPublished { get; set; }
        [Range(0, 4)]
        [XmlElement(nameof(CategoryType))]
        public int CategoryType { get; set; }
        public string Mechanics { get; set; } = null!;
    }
}
