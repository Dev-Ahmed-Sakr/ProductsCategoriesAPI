﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCategoryAccess.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public Category? ParentCategory { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<Product> Products { get; set; }
    }
}
