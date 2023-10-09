using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace DigitalStore.Models.EF
{
    [Table("tn_Game")]
    public class Game : CommonAbstract
    {
        public Game()
        {
            this.GameNews = new HashSet<GameNews>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }

        public virtual GameGenre GameGenre { get; set; }
        public virtual Publisher Publisher { get; set; }
        public ICollection<GameNews> GameNews { get; set; }

    }
}