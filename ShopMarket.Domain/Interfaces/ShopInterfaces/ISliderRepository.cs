using System.Linq;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces
{
    public interface ISliderRepository
    {
        IQueryable<Slide> GetAll();

        void InsertSlide(Slide slide);

        void DeleteSlide(Slide slide);

        void Save();
    }
}