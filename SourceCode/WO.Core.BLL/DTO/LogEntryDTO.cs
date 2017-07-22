namespace WO.Core.BLL.DTO
{
    public class LogEntryDTO : BaseModelDTO
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Level { get; set; }
    }
}
