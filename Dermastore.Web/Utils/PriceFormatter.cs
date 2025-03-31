using Dermastore.Application.DTOs;

namespace Dermastore.Web.Utils
{
    public static class PriceFormatter
    {
        public static string FormatPrice(decimal price)
        {
            return string.Format("{0}đ", price.ToString("N0"));
        }
    }
}
