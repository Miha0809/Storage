using System;

namespace Storage.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual DateTime OrderDateTime { get; set; }
        
        public virtual Product Products { get; set; }
    }
}