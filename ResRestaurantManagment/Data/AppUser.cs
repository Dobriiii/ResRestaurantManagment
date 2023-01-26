using Microsoft.AspNetCore.Identity;

namespace ResRestaurantManagment.Data
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Lists = new List<ResList>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public virtual List<ResList> Lists { get; set; }

    }
}
