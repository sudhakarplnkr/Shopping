namespace Inventory.WebApi.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Mobile { get; set; }

        public string Email { get; set; }
    }
}