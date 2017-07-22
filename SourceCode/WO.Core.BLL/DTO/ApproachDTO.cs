namespace WO.Core.BLL.DTO
{
    public class ApproachDTO : BaseModelDTO
    {
        public int PlannedTimeForRest { get; set; }
        public int SpentTimeForRest { get; set; }

        public SetDTO Set { get; set; }
        public int? SetId { get; set; }
    }
}
