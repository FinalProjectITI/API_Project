using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API_Project.Models
{
    public partial class Favourit
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual Product Product { get; set; }
    }
}
