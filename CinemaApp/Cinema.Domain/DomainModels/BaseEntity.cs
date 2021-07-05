using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Domain.DomainModels
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
