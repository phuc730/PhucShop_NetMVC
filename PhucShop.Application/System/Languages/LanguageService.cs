using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhucShop.Data.EF;
using PhucShop.ViewModels.Common;
using PhucShop.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IConfiguration _configuration;
        private readonly PShopDbContext _context;

        public LanguageService(IConfiguration configuration, PShopDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<ApiResult<List<LanguageViewModel>>> GetAll()
        {
            var langguages = await _context.Languages.Select(x => new LanguageViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return new ApiResultSuccessed<List<LanguageViewModel>>(langguages);
        }
    }
}