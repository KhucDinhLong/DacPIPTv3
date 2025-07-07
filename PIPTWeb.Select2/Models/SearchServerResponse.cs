﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace PIPTWeb.Select2 {
    public class SearchServerResponse {
        [JsonProperty("pagination")]
        public PaginationOptions Pagination { get; set; } = new PaginationOptions();
        [JsonProperty("results")]
        public IEnumerable<Select2Item> Results { get; set; }
    }
}
