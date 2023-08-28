using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName
{
    public class GetCarWorkshopByEncodedNameQuery : IRequest<CarWorkshopDto>
    {
        public string EncodedName { get; set; }

        public GetCarWorkshopByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }

    }
}
