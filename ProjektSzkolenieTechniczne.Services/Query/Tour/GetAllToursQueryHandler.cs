using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczneService.Query.Dtos;
using SzkolenieTechniczneStorage.Repository;
namespace SzkolenieTechniczneService.Query.Tour
{
    public sealed class GetAllToursQueryHandler : IQueryHandler<GetAllToursQuery, List<TourDto>>
    {
        private readonly ITourRepository _repository;

        public GetAllToursQueryHandler(ITourRepository repository)
        {
            _repository = repository;
        }

        public List<TourDto> Handle(GetAllToursQuery query)
        {
            var tours = _repository.GetTours();

            return tours.Select(item => new TourDto(item.Id, item.Destination)).ToList();
        }
    }
}
