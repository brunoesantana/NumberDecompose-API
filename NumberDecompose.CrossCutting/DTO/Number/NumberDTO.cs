using System;
using System.Collections.Generic;

namespace NumberDecompose.CrossCutting.DTO.Number
{
    public class NumberDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public IList<int> Divisors { get; set; }
        public IList<int> PrimeDivisors { get; set; }
    }
}