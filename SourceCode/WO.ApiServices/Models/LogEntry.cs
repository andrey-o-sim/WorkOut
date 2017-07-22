namespace WO.ApiServices.Models
{
    public class LogEntry : BaseModel
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Level { get; set; }
    }
}