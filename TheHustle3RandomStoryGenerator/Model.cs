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
        private int _goodScore;
        private int _badScore;
        private int _neutralScore;

        public bool IsCharacterDead()
        {
            return _isDead;
        }
        public void ToggleLife()
        {
            _isDead = !_isDead;
        }
        public int GetAlignmentScore(Alignment a)
        {
            switch (a)
            {
                case Alignment.Good:
                    return _goodScore;
                case Alignment.Neutral:
                    return _neutralScore;
                case Alignment.Evil:
                    return _badScore;
                default:
                    return _neutralScore;
            }
        }
        public void SetAlignmentScore(Alignment a, int val)
        {
            switch (a)
            {
                case Alignment.Good:
                    _goodScore = val;
                    break;
                case Alignment.Neutral:
                    _neutralScore = val;
                    break;
                case Alignment.Evil:
                    _badScore = val;
                    break;
                default:
                    _neutralScore = val;
                    break;
            }
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

        public void SetAlignment(Alignment alignment)
        {
            _alignment = alignment;
        }

        public void SetName(string name)
        {
            _name = name;
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
