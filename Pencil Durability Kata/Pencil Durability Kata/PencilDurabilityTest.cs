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

        [Fact]
        public void WhenDurabilityIsOneAndPencilDurabilityWritesTwoLettersReturnOnlyFirstLetter()
        {
            PencilDurability pencilDurability = new PencilDurability(1);
            string result = pencilDurability.Write("te");
            Assert.Equal("t", result);
        }

        [Fact]
        public void WhenDurabilityIsTwoAndPencilDurabilityWritesTwoLettersReturnSameTwoLetters()
        {
            PencilDurability pencilDurability = new PencilDurability(2);
            string result = pencilDurability.Write("te");
            Assert.Equal("te", result);
        }

        [Fact]
        public void WhenDurabilityIsOneAndPencilDurabilityWritesCapitalLetterReturnEmptyString()
        {
            PencilDurability pencilDurability = new PencilDurability(1);
            string result = pencilDurability.Write("A");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void WhenDurabilityIsTwoAndPencilDurabilityWritesOneCapitalLetterReturnThatCapitalLetter()
        {
            PencilDurability pencilDurability = new PencilDurability(2);
            string result = pencilDurability.Write("A");
            Assert.Equal("A", result);
        }
    }
}
