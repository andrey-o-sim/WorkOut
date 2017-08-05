namespace WO.Core.DAL.Model
{
    public class ApproachResult : BaseModel
    {
        public int MadeNumberOfTimes { get; set; }
        public string Description { get; set; }

        public int? SetTargetId { get; set; }
        public virtual SetTarget SetTarget { get; set; }
        public int? ApproachId { get; set; }
        public virtual Approach Approach { get; set; }
    }
}
