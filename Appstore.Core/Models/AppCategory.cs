using System.Collections.Generic;

namespace Appstore.Core.Models
{
    public class AppCategory
    {
        public string Name { get; set; }
        public IEnumerable<StoreApp> Apps { get; set; }
    }
}
