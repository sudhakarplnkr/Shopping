namespace Inventory.WebApi.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public double Mobile { get; private set; }

        public string Email { get; private set; }
    }
}