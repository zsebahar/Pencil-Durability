using System;
using Xunit;

namespace Pencil_Durability_Kata
{
    public class PencilDurabilityTest
    {
        [Fact]
        public void WhenDurabilityIsOneAndPencilDurabilityWritesOneLetterReturnSameLetter()
        {
            PencilDurability pencilDurability = new PencilDurability(1);
            string result = pencilDurability.Write("t");
            Assert.Equal("t", result);
        }
    }
}
