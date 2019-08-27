using System;
using Xunit;

namespace Pencil_Durability_Kata
{
    public class PencilDurabilityTest
    {
        [Fact]
        public void WhenDurabilityIsOneAndPencilDurabilityWritesOneLetterReturnSameLetter()
        {
            PencilDurability pencilDurability = new PencilDurability(1, 1);
            string result = pencilDurability.Write("t");
            Assert.Equal("t", result);
        }

        [Fact]
        public void WhenDurabilityIsOneAndPencilDurabilityWritesTwoLettersReturnOnlyFirstLetter()
        {
            PencilDurability pencilDurability = new PencilDurability(1, 1);
            string result = pencilDurability.Write("te");
            Assert.Equal("t", result);
        }

        [Fact]
        public void WhenDurabilityIsTwoAndPencilDurabilityWritesTwoLettersReturnSameTwoLetters()
        {
            PencilDurability pencilDurability = new PencilDurability(2, 1);
            string result = pencilDurability.Write("te");
            Assert.Equal("te", result);
        }

        [Fact]
        public void WhenDurabilityIsOneAndPencilDurabilityWritesCapitalLetterReturnEmptyString()
        {
            PencilDurability pencilDurability = new PencilDurability(1, 1);
            string result = pencilDurability.Write("A");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void WhenDurabilityIsTwoAndPencilDurabilityWritesOneCapitalLetterReturnThatCapitalLetter()
        {
            PencilDurability pencilDurability = new PencilDurability(2, 1);
            string result = pencilDurability.Write("A");
            Assert.Equal("A", result);
        }

        [Fact]
        public void WhenDurabilityIsTwoAndPencilDurabilityWritesOneLowerCaseLetterAndSpaceDurabilityIsOne()
        {
            PencilDurability pencilDurability = new PencilDurability(2, 1);
            pencilDurability.Write("a ");
            int durability = pencilDurability.GetDurability();
            Assert.Equal(1, durability);
        }

        [Fact]
        public void WhenDurabilityIsTwoAndPencilDurabilityWritesOneLowerCaseLetterAndNewlineDurabilityIsOne()
        {
            PencilDurability pencilDurability = new PencilDurability(2, 1);
            pencilDurability.Write("a\n");
            int durability = pencilDurability.GetDurability();
            Assert.Equal(1, durability);
        }

        [Fact]
        public void WhenPencilDurabilityCallsInitializePaperMethodThenTextOnPaperCanBeRead()
        {
            PencilDurability pencilDurability = new PencilDurability(1, 1);
            string paper = "Test paper";
            pencilDurability.InitializePaper(paper);
            Assert.Equal("Test paper", pencilDurability.GetPaperText());
        }

        [Fact]
        public void VerifyPencilAppendsTextToPaperWithExistingText()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 1);
            string paper = "Test paper";
            pencilDurability.InitializePaper(paper);
            pencilDurability.Write(" appending");
            Assert.Equal("Test paper appending", pencilDurability.GetPaperText());
        }

        [Fact]
        public void VerifyWhenPencilIsSharpenedTheLengthIsReducedByOne()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 2);
            pencilDurability.Sharpen();
            Assert.Equal(1, pencilDurability.GetLength());
        }

        [Fact]
        public void VerifyWhenPencilIsSharpenedItRegainsInitialDurability()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 2);
            pencilDurability.Sharpen();
            pencilDurability.Write("test");
            pencilDurability.Sharpen();
            Assert.Equal(10, pencilDurability.GetDurability());
        }
    }
}
