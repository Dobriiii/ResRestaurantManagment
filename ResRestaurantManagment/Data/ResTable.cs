namespace ResRestaurantManagment.Data
{
    public class ResTable
    {
        public int Id { get; set; }
        public int Table { get; set; }
        public int Slots { get; set; }
        public bool IsSmoking { get; set; }
        public virtual ResList? ResList { get; set; }

    }
}