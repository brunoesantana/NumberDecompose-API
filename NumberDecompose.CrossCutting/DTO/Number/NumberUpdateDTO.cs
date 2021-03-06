using NumberDecompose.CrossCutting.DTO.Base;
using System.ComponentModel.DataAnnotations;

namespace NumberDecompose.CrossCutting.DTO.Number
{
    public class NumberUpdateDTO : BaseUpdateDTO
    {
        [Required]
        public int Value { get; set; }
    }
}