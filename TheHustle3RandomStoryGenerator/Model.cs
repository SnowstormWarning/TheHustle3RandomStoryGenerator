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

    public class Scene
    {
        public string Prompt;
        public string GoodChoice;
        public string NeutralChoice;
        public string BadChoice;
    }

    public class Character : Noun
    {
        private bool _isDead;
        private Word _nameWord;

        public bool IsCharacterDead()
        {
            return _isDead;
        }

    }
    public class Word
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

    public class Noun: Word
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
    
    public class Adjective : Word
    {

    }

    public class Verb : Word
    {

    }
}
