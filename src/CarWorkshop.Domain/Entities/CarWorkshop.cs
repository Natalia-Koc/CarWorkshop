using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Entities
{
    public class CarWorkshop
    {
        public int Id { get; set; }        //required - wymagane 
        public string Name { get; set; } = default!;
        public string? Description { get; set; }        //może być null
        public DateTime CreatedAt { get; set; } = DateTime.Now;     //od razu wpisywana wartość
        public CarWorkshopContact ContactDetails { get; set; } = default!;      //odniesienie do elementu modelu CarWorkshopContact
        public string? About { get; set; }

        public string EncodedName { get; private set; } = default!;

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");

    }
}
