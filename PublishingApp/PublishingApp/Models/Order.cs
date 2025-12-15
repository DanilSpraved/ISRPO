using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PublishingApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string Type { get; set; }
        public string BookTitle { get; set; }
        public string CustomerName { get; set; }
        public string OfficeName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal Price { get; set; }
    }
}