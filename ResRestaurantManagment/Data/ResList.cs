using System.ComponentModel.DataAnnotations;

namespace ResRestaurantManagment.Data
{
    public class ResList
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }
        public DateTime ResDate { get; set; }
        public int TableId { get; set; }
        public virtual List<ResTable> Tables { get; set; }
        public string Description { get; set; }

        public ResList()
        {
            Tables = new List<ResTable>(); 
        }
    }
}