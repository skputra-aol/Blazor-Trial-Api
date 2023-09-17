using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BlazorApp.Helpers.Pagination
{

    public class PagingResponse<T> where T : class
    {
        public IEnumerable<T> data { get; set; }
        public Meta meta { get; set; }
    }

    public class PagingParam
    {
        public int page { get; set; }
        public int perPage { get; set; }
    }
    public class Meta
    {
        public Pagination pagination { get; set; }
    }

    public class Pagination
    {
        public int total { get; set; }
        public int count { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public Links links { get; set; }
    }

    public class Links
    {
        public string next { get; set; }
    }


}