using NumberDecompose.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NumberDecompose.Domain
{
    public class Number : EntityBase
    {
        [Required]
        [Column(TypeName = "INT")]
        public int Value { get; set; }
    }
}