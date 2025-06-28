using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class PartsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPartRepository _partRepository;

        public IList<Part> Parts { get; set; }

        public PartsModel(ILogger<IndexModel> logger, IPartRepository partRepository)
        {
            _logger = logger;
            _partRepository = partRepository;
            Parts = new List<Part>();
        }

        public void OnGet()
        {
            Parts = _partRepository.GetAllParts().ToList();
            _logger.LogInformation($"getting all {Parts.Count} customers");
        }
    }
}
