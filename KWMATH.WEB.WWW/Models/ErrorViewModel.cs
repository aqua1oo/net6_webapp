namespace KWMATH.WEB.WWW.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public int StatusCd { get; set; }        
    }
}