namespace WO.Core.DAL.Model
{
    public class Approach : BaseModel
    {
        public int PlannedTimeForRest { get; set; }
        public int SpentTimeForRest { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }

        public virtual Set Set { get; set; }
        public int? SetId { get; set; }
    }
}
