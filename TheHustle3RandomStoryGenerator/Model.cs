using System;
using System.Collections.Generic;
using System.Text;

namespace TheHustle3RandomStoryGenerator
{

    public enum Alignment
    {
        Good,
        Neutral,
        Evil
    }

    class Scene
    {
        public string Prompt;
        public string GoodChoice;
        public string NeutralChoice;
        public string BadChoice;
    }

    class Character : Noun
    {
        private bool _isDead;
        private Word _nameWord;

        public bool IsCharacterDead()
        {
            return _isDead;
        }

    }
    class Word
    {

        private string _name;
        private Alignment _alignment;
        public override string ToString()
        {
            return _name;
        }

        public Alignment GetAlignment()
        {
            return _alignment;
        }

    }

    class Noun: Word
    {
        public string MakeCapital()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach(char c in this.ToString())
            {
                if(i == 0)
                {
                    sb.Append(c.ToString().ToUpper());
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
    
    class Adjective : Word
    {

    }

    class Verb : Word
    {

    }
}
