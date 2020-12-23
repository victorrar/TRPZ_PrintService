using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TRPZ_PrintService.Data;

namespace TRPZ_PrintService.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TRPZ_PrintServiceUser class
    public class TRPZ_PrintServiceUser : IdentityUser
    {
        [PersonalData] public string FirstName { get; set; }
        [PersonalData] public string LastName { get; set; }
        public IList<Order> Orders {get; set; }
    }
}