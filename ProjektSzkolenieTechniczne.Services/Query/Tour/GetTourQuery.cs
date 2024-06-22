using SzkolenieTechniczneService.Query;
using SzkolenieTechniczneService.Query.Dtos;

namespace ProjektSzkolenieTechniczne.Services.Query.Tour
{
    public class GetTourQuery : IQuery<TourDetailsDto>
    {
        public long TourId { get; set; }

        public GetTourQuery(long tourId)
        {
            TourId = tourId;
        }
    }
}
