using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NumberDecompose.Domain.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Date = DateTime.Now;
            Version = 1;
            Active = true;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Version { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Active { get; set; }
    }
}