using System.Collections.Generic;

namespace NumberDecompose.Tests.Helper
{
    public static class TestHelper
    {
        public static List<int> GetNumbersList()
        {
            return new List<int> { 1, 3, 5, 9, 15, 45 };
        }

        public static List<int> GetEmptyList()
        {
            return new List<int>();
        }
    }
}