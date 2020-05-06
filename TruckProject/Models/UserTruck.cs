using System;
using System.Collections.Generic;

namespace TruckProject.Models
{
    public partial class UserTruck
    {
        public long UserId { get; set; }
        public long TruckId { get; set; }

        public virtual Truck Truck { get; set; }
        public virtual Users User { get; set; }
    }
}
