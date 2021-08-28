using System.ComponentModel.DataAnnotations;

namespace NumberDecompose.CrossCutting.DTO.Number
{
    public class NumberInsertDTO
    {
        [Required]
        public int Value { get; set; }
    }
}