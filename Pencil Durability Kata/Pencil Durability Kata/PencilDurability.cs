using System;
using System.Collections.Generic;

namespace Pencil_Durability_Kata
{
    internal class PencilDurability
    {
        private int durability;
        private string paper;
        private int length;
        private int initialDurability;

        public PencilDurability(int durability, int length)
        {
            this.durability = durability;
            initialDurability = durability;
            this.paper = string.Empty;
            this.length = length;
        }

        public string Write(string textToWrite)
        {
            for(int i = 0; i < textToWrite.Length; i++)
            {
                if (Char.IsUpper(textToWrite[i]))
                {
                    durability -= 2;
                }
                else if(textToWrite[i] != ' ' && textToWrite[i] != '\n')
                {
                    durability--;
                }
                if (durability < 0)
                {
                    break;
                }
                paper += textToWrite[i];
            }
            return paper;
        }

        public int GetDurability()
        {
            return durability;
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
            length -= 1;
            durability = initialDurability;
        }

        public int GetLength()
        {
            return length;
        }
    }
}