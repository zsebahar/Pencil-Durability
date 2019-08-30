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
                ReduceDurabilityBasedOnCharacter(textToWrite[i]);
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
            string newPaperReversed = string.Empty;
            for(int i = paper.Length - 1; i >= 0; i--)
            {
                if((i < startIndex || i > lastIndex) || eraserDurability == 0)
                {
                    newPaperReversed += paper[i];
                }
                else
                {
                    newPaperReversed += ' ';
                    if (paper[i] != ' ')
                    {
                        eraserDurability--;
                    }
                }
            }
            char[] newPaper = newPaperReversed.ToCharArray();
            Array.Reverse(newPaper);
            paper = new string(newPaper);
        }

        public int GetEraserDurability()
        {
            return eraserDurability;
        }

        public void Edit(int startIndex, string textToAdd)
        {
            int lastIndex = startIndex + textToAdd.Length - 1;
            string newPaper = string.Empty;
            int textToAddIndex = 0;
            for (int i = 0; i < paper.Length; i++)
            {
                if ((i < startIndex || i > lastIndex) || eraserDurability == 0)
                {
                    newPaper += paper[i];
                }
                else
                {
                    ReduceDurabilityBasedOnCharacter(textToAdd[textToAddIndex]);
                    if (pencilDurability >= 0)
                    {
                        if (paper[i] != ' ')
                        {
                            newPaper += '@';
                        }
                        else
                        {
                            newPaper += textToAdd[textToAddIndex];
                        }
                        textToAddIndex++;
                    }
                    else
                    {
                        newPaper += ' ';
                    }
                    
                }
            }
            paper = newPaper;
        }

        private void ReduceDurabilityBasedOnCharacter(char character)
        {
            if (char.IsUpper(character))
            {
                pencilDurability -= 2;
            }
            else if (character != ' ' && character != '\n')
            {
                pencilDurability--;
            }
        }
    }
}