namespace Inventory.WebApi.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        [Key]
        public Guid Id { get; private set; }

        public string Code { get; private set; }
     
        public string Description { get; private set; }
    }
}