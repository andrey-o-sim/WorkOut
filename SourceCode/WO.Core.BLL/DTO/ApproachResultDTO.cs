namespace WO.Core.BLL.DTO
{
    public class ApproachResultDTO : BaseModelDTO
    {
        public int MadeNumberOfTimes { get; set; }
        public string Description { get; set; }

        public int? SetTargetId { get; set; }
        public SetTargetDTO SetTarget { get; set; }
        public int? ApproachId { get; set; }
        public ApproachDTO Approach { get; set; }
    }
}
