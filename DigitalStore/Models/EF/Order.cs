using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalStore.Models.EF
{
    [Table("tb_Order")]
    public class Order : CommonAbstract
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Order_Code { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime Order_Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int TypePayment {  get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}