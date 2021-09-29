using System;
using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Domain.BaseEntities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}