using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories
{
    public class SliderRepository : ISliderRepository
    {
        private readonly ShopMarketDbContext _context;

        public SliderRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public IQueryable<Slide> GetAll()
        {
            return _context.Slides.AsNoTracking();
        }

        public void InsertSlide(Slide slide)
        {
            _context.Add(slide);
        }

        public void DeleteSlide(Slide slide)
        {
            _context.Remove(slide);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}