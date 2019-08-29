using System;
using Xunit;

namespace Pencil_Durability_Kata
{
    public class PencilDurabilityTest
    {
        [Fact]
        public void VerifyWhenDurabilityIsOneAndPencilWritesOneLetterTheSameLetterIsReturned()
        {
            PencilDurability pencilDurability = new PencilDurability(1, 1, 10);
            string result = pencilDurability.Write("t");
            Assert.Equal("t", result);
        }

        [Fact]
        public void VerifyWhenDurabilityIsOneAndPencilWritesTwoLettersOnlyFirstLetterIsReturned()
        {
            PencilDurability pencilDurability = new PencilDurability(1, 1, 10);
            string result = pencilDurability.Write("te");
            Assert.Equal("t", result);
        }

        [Fact]
        public void VerifyWhenDurabilityIsTwoAndPencilWritesTwoLettersSameTwoLettersAreReturned()
        {
            PencilDurability pencilDurability = new PencilDurability(2, 1, 10);
            string result = pencilDurability.Write("te");
            Assert.Equal("te", result);
        }

        [Fact]
        public void VerifyWhenDurabilityIsOneAndPencilWritesACapitalLetterAnEmptyStringIsReturned()
        {
            PencilDurability pencilDurability = new PencilDurability(1, 1, 10);
            string result = pencilDurability.Write("A");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void VerifyWhenDurabilityIsTwoAndPencilWritesOneCapitalLetterTheSameLetterIsReturned()
        {
            PencilDurability pencilDurability = new PencilDurability(2, 1, 10);
            string result = pencilDurability.Write("A");
            Assert.Equal("A", result);
        }

        [Fact]
        public void VerifyWhenDurabilityIsTwoAndPencilWritesOneLowerCaseLetterAndOneSpaceDurabilityIsOne()
        {
            PencilDurability pencilDurability = new PencilDurability(2, 1, 10);
            pencilDurability.Write("a ");
            int durability = pencilDurability.GetPencilDurability();
            Assert.Equal(1, durability);
        }

        [Fact]
        public void VerifyWhenDurabilityIsTwoAndPencilWritesOneLowerCaseLetterAndNewlineDurabilityIsOne()
        {
            PencilDurability pencilDurability = new PencilDurability(2, 1, 10);
            pencilDurability.Write("a\n");
            int durability = pencilDurability.GetPencilDurability();
            Assert.Equal(1, durability);
        }

        [Fact]
        public void VerifyWhenPaperIsInitializedThenTextOnPaperCanBeRead()
        {
            PencilDurability pencilDurability = new PencilDurability(1, 1, 10);
            string paper = "Test paper";
            pencilDurability.InitializePaper(paper);
            Assert.Equal("Test paper", pencilDurability.GetPaperText());
        }

        [Fact]
        public void VerifyPencilAppendsTextToPaperWithExistingText()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 1, 10);
            string paper = "Test paper";
            pencilDurability.InitializePaper(paper);
            pencilDurability.Write(" appending");
            Assert.Equal("Test paper appending", pencilDurability.GetPaperText());
        }

        [Fact]
        public void VerifyWhenPencilIsSharpenedTheLengthIsReducedByOne()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 2, 10);
            pencilDurability.Sharpen();
            Assert.Equal(1, pencilDurability.GetLength());
        }

        [Fact]
        public void VerifyWhenPencilIsSharpenedItRegainsInitialDurability()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 2, 10);
            pencilDurability.Sharpen();
            pencilDurability.Write("test");
            pencilDurability.Sharpen();
            Assert.Equal(10, pencilDurability.GetPencilDurability());
        }

        [Fact]
        public void VerifyWhenPencilIsSharpenedAndLengthIsZeroInitialDurabilityIsNotRegained()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 0, 10);
            pencilDurability.Sharpen();
            pencilDurability.Write("test");
            pencilDurability.Sharpen();
            Assert.Equal(6, pencilDurability.GetPencilDurability());
        }

        [Fact]
        public void VerifyWhenTheWordTestIsErasedThenLastOccurrenceOfTestOnPaperIsReplacedWithWhitespace()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 1, 10);
            string paper = "Test my eraser test";
            pencilDurability.InitializePaper(paper);
            pencilDurability.Erase("test");
            Assert.Equal("Test my eraser     ", pencilDurability.GetPaperText());
        }

        [Fact]
        public void VerifyWhenWordOccursTwiceOnPaperAndEraseCalledTwiceForThatWordBothOccurrencesAreErased()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 1, 10);
            string paper = "test my eraser test";
            pencilDurability.InitializePaper(paper);
            pencilDurability.Erase("test");
            pencilDurability.Erase("test");
            Assert.Equal("     my eraser     ", pencilDurability.GetPaperText());
        }

        [Fact]
        public void VerifyWhenEraserDurabilityIsFourAndWordBillIsErasedThenEraserDurabilityIsZero()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 1, 4);
            string paper = "Buffalo Bill";
            pencilDurability.InitializePaper(paper);
            pencilDurability.Erase("Bill");
            Assert.Equal(0, pencilDurability.GetEraserDurability());
        }

        [Fact]
        public void VerifyWhenEraserDurabilityIsFiveAndWordBillIsErasedWithSpaceThenEraserDurabilityIsOne()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 1, 5);
            string paper = "Buffalo Bill";
            pencilDurability.InitializePaper(paper);
            pencilDurability.Erase(" Bill");
            Assert.Equal(1, pencilDurability.GetEraserDurability());
        }

        [Fact]
        public void VerifyWhenEraserDurabilityIsThreeAndBillIsErasedThenOnlyFirstLetterOfBillRemains()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 1, 3);
            string paper = "Buffalo Bill";
            pencilDurability.InitializePaper(paper);
            pencilDurability.Erase("Bill");
            Assert.Equal("Buffalo B   ", pencilDurability.GetPaperText());
        }

        [Fact]
        public void VerifyWhenPaperHasFiveConsecutiveWhiteSpacesWordTheCanBeAddedToMiddleThreeWhiteSpacesOnPaper()
        {
            PencilDurability pencilDurability = new PencilDurability(10, 1, 3);
            string paper = "This is     paper";
            pencilDurability.InitializePaper(paper);
            pencilDurability.Edit(8, "the");
            string result = pencilDurability.GetPaperText();
            Assert.Equal("This is the paper", pencilDurability.GetPaperText());
        }
    }
}
