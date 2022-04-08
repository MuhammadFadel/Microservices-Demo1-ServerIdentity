using static Demo1.Web.SD;

namespace Demo1.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
