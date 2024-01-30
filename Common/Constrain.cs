using Microsoft.Identity.Client;

namespace WebPhoneEcommerce.Common
{
    public static class Constrain
    {
        public static string HostApi = "http://localhost:7007/";
        
        public class GetApi
        {
            public static string Details = "Show-Product";

            public static string Danhsach = "api/ApiCurd/Show-danh-sach";
        }
        public class PostApi
        {
            public static string Post = "api/ApiCurd/them-san-pham";
        }
        public class DeletApi
        {
           public static string Delete = "api/ApiCurd/Xoa-san-pham";
        }
        public class UpdateApi
        {
            public static string Update = "api/ApiCurd/cap-nhat-san-pham";
        }


    }
}
