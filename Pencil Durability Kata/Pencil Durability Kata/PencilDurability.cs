using System;

namespace Pencil_Durability_Kata
{
    internal class PencilDurability
    {
        private int durability;

        public PencilDurability(int durability)
        {
            this.durability = durability;
        }

        public string Write(string textToWrite)
        {
            string result = string.Empty;
            for(int i = 0; i < textToWrite.Length; i++)
            {
                if (Char.IsUpper(textToWrite[i]))
                {
                    durability -= 2;
                }
                else
                {
                    durability--;
                }
                if (durability < 0)
                {
                    break;
                }
                result += textToWrite[i];
            }
            return result;
        }
    }
}