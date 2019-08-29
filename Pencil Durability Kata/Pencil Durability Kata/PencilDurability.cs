using System;
using System.Collections.Generic;

namespace Pencil_Durability_Kata
{
    internal class PencilDurability
    {
        private int pencilDurability;
        private string paper;
        private int length;
        private readonly int initialDurability;
        private int eraserDurability;

        public PencilDurability(int pencilDurability, int length, int eraserDurability)
        {
            this.pencilDurability = pencilDurability;
            initialDurability = pencilDurability;
            paper = string.Empty;
            this.length = length;
            this.eraserDurability = eraserDurability;
        }

        public string Write(string textToWrite)
        {
            for(int i = 0; i < textToWrite.Length; i++)
            {
                if (char.IsUpper(textToWrite[i]))
                {
                    pencilDurability -= 2;
                }
                else if(textToWrite[i] != ' ' && textToWrite[i] != '\n')
                {
                    pencilDurability--;
                }
                if (pencilDurability < 0)
                {
                    break;
                }
                paper += textToWrite[i];
            }
            return paper;
        }

        public int GetPencilDurability()
        {
            return pencilDurability;
        }

        public void InitializePaper(string paper)
        {
            this.paper = paper;
        }

        public string GetPaperText()
        {
            return paper;
        }

        public void Sharpen()
        {
            if (length > 0)
            {
                length -= 1;
                pencilDurability = initialDurability;
            }
        }

        public int GetLength()
        {
            return length;
        }

        public void Erase(string erasedText)
        {
            int startIndex = paper.LastIndexOf(erasedText);
            int lastIndex = startIndex + erasedText.Length - 1;
            string newPaper = string.Empty;
            for(int i = paper.Length - 1; i >= 0; i--)
            {
                if((i < startIndex || i > lastIndex) || eraserDurability == 0)
                {
                    newPaper += paper[i];
                }
                else
                {
                    newPaper += ' ';
                    if (paper[i] != ' ')
                    {
                        eraserDurability--;
                    }
                }
            }
            char[] reversedString = newPaper.ToCharArray();
            Array.Reverse(reversedString);
            paper = new string(reversedString);
        }

        public int GetEraserDurability()
        {
            return eraserDurability;
        }
    }
}