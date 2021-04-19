using System.Collections.Generic;

namespace Lib.Repository.Dto
{
    public class MenuViewModel
    {
        public string Title { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Icon { get; set; }

        public List<MenuViewModel> ListMenuChild { get; set; }
    }
}
