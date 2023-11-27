using Promocoes.Domain.Enums;
using Promocoes.Domain.Validations;
using Promocoes.Domain.Validations.Interfaces;
using Promocoes.Domain.ValueObjects;

namespace Promocoes.Domain.Entities
{
    public class BusinessEntity : BaseEntity, IValidate
    {
        public BusinessEntity(string name, string description, string logo, string location, Contacts contacts,
         ECategory category, string operation, string geoData, string idUser)
        {
            IdBusiness = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Logo = logo;
            Location = location;
            Contacts = contacts;
            Category = category;
            Operation = operation;
            GeoData = geoData;
            IdUser = idUser;
        }

        public string IdBusiness { get; private set; }
        public string IdUser { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Logo { get; private set; }
        public string Location { get; private set; }
        public Contacts Contacts { get; private set; }
        public ECategory Category { get; set; }
        public string Operation { get; private set; }
        public string GeoData { get; private set; }
        

        public bool IsValid()
        {
            return new BusinessValidations(this).GuidIsValid()
                .NameLength()
                .DescriptionLenght()
                .EmailIsValid()
                .NumberIsValid()
                .IsValid();
        }
    }
}