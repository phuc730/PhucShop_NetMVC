using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhucShop.Data.EF;
using PhucShop.Data.Entities;
using PhucShop.ViewModels.System.Roles;
using PhucShop.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.Application.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly PShopDbContext _context;

        public SlideService(PShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<SlideViewModel>> GetAll()
        {
            var slides = await _context.Slides
                .Select(x => new SlideViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    SortOrder = x.SortOrder,
                    Url = x.Url
                }).ToListAsync();

            return slides;
        }
    }
}