using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.Data.Models
{
    public class Citizen
    {
        public Citizen()
        {
            PropertiesCitizens = new HashSet<PropertyCitizen>();
        }

        public int Id { get; set; }
        [MaxLength(ValidationConstants.CitizenFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [MaxLength(ValidationConstants.CitizenLastNameMaxLength)]
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
    }

    //•	PropertiesCitizens - collection of type PropertyCitizen

}
