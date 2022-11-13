using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TheHustle3RandomStoryGenerator
{
    class Controller
    {
        public List<Word> Words;
        public List<Noun> Nouns;
        public List<Adjective> Adjectives;
        public List<Verb> Verbs;
        public List<Character> Characters = new List<Character>();
        public Character You = new Character();

        public Controller()
        {
            Words = new List<Word>();
            Nouns = new List<Noun>();
            Adjectives = new List<Adjective>();
            Verbs = new List<Verb>();
            using (StreamReader reader = new StreamReader(Directory.GetParent(Environment.CurrentDirectory).
                Parent.FullName.
                Substring(0, Directory.GetParent(Environment.CurrentDirectory).Parent.FullName.Length-4)
                + "/wordsFile.txt"))
            {
                Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/wordsFile.txt");
                int phase = 0;
                while (!reader.EndOfStream)
                {
                    string currentLine = reader.ReadLine();
                    switch (currentLine)
                    {
                        case "NOUNS":
                            phase = 0;
                            break;
                        case "ADJECTIVES":
                            phase = 1;
                            break;
                        case "VERBS":
                            phase = 2;
                            break;
                        default:
                            string word = currentLine;
                            Alignment alignment = (Alignment)(Int32.Parse(reader.ReadLine()));
                            switch(phase)
                            {
                                case 0:
                                    Noun noun = new Noun();
                                    noun.SetAlignment(alignment);
                                    noun.SetName(word);
                                    Nouns.Add(noun);
                                    break;
                                case 1:
                                    Adjective adj = new Adjective();
                                    adj.SetAlignment(alignment);
                                    adj.SetName(word);
                                    Adjectives.Add(adj);
                                    break;
                                case 2:
                                    Verb verb = new Verb();
                                    verb.SetAlignment(alignment);
                                    verb.SetName(word);
                                    Verbs.Add(verb);
                                    break;
                            }

                            break;
                    }
                }
                foreach(Word word in Nouns)
                {
                    Words.Add(word);
                }
                foreach (Word word in Adjectives)
                {
                    Words.Add(word);
                }
                foreach (Word word in Verbs)
                {
                    Words.Add(word);
                }
            }
        }

        public string ConstructSentence(Alignment alignment)
        {
            return ConstructSubject(alignment) +" "+ ConstructPredicate(alignment);
        }

        public string ConstructSubject(Alignment alignment)
        {
            Random random = new Random();
            if(random.Next(20) < 17)
            {
                Noun noun;
                noun = Nouns[random.Next(Nouns.Count)];
                while(noun.GetAlignment() != alignment)
                {
                    noun = Nouns[random.Next(Nouns.Count)];
                }
                return (noun.MakeCapital());
            }
            else
            {
                Noun noun1;
                Noun noun2;
                noun1 = Nouns[random.Next(Nouns.Count)];
                while (noun1.GetAlignment() != alignment)
                {
                    noun1 = Nouns[random.Next(Nouns.Count)];
                }
                noun2 = Nouns[random.Next(Nouns.Count)];
                while (noun2.GetAlignment() != alignment && noun2 != noun1)
                {
                    noun2 = Nouns[random.Next(Nouns.Count)];
                }
                return noun1.MakeCapital() + " and " + noun2.ToString();
            }
        }

        public string ConstructPredicate(Alignment alignment)
        {
            List<Noun> nouns = new List<Noun>();
            List<Adjective> adjectives = new List<Adjective>();
            List<Verb> verbs = new List<Verb>();
            string predicate = "";
            foreach (Word word in Words)
            {
                if (word.GetAlignment() == alignment)
                {
                    if (word is Noun)
                    {
                        nouns.Add((Noun)word);
                    }
                    else if (word is Verb)
                    {
                        verbs.Add((Verb)word);
                    }
                    else if (word is Adjective)
                    {
                        adjectives.Add((Adjective)word);
                    }
                }
            }
                Random random = new Random();
                switch (random.Next(4))
                {
                    case 0: // V ed the
                        predicate += verbs[random.Next(verbs.Count)].ToString() +"ed the ";
                        break;
                    case 1:
                        predicate += " is "+verbs[random.Next(verbs.Count)].ToString() + "ing the ";
                        break;
                    case 2:
                        predicate += verbs[random.Next(verbs.Count)].ToString() + " a ";
                        break;
                    default:
                        predicate += " will "+verbs[random.Next(verbs.Count)].ToString() + " the ";
                        break;
                }
                predicate += nouns[random.Next(nouns.Count)].ToString()+" ";
                int iMax = random.Next(6);
                for (int i = 0; i < iMax; i++)
                {
                    switch (random.Next(6))
                    {
                        case 0:
                            predicate += "in the " + nouns[random.Next(nouns.Count)].ToString()+ " ";
                            break;
                        case 1:
                            predicate += "in the " + adjectives[random.Next(adjectives.Count)].ToString() + " " + nouns[random.Next(nouns.Count)].ToString() + " ";
                            break;
                        case 2:
                            predicate += "at the " + nouns[random.Next(nouns.Count)].ToString() + " ";
                            break;
                        case 3:
                            predicate += "at the " + adjectives[random.Next(adjectives.Count)].ToString() + " " + nouns[random.Next(nouns.Count)].ToString() + " ";
                            break;
                        case 4:
                            predicate += "at the " + nouns[random.Next(nouns.Count)].ToString() + " ";
                            break;
                        case 5:
                            predicate += "at the " + adjectives[random.Next(adjectives.Count)].ToString() + " " + nouns[random.Next(nouns.Count)].ToString() + " ";
                            break;
                    }
                }
            return predicate += ".";
        }

        /// <summary>
        /// Getting the name from the view I think
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "";
        }


        public Scene StartAdventure()
        {
            Scene startScene = new Scene();

            string megaSentence = "";
            //Character you = new Character();
            You.ToggleLife();
            You.SetName(GetName());
            You.SetAlignmentScore(Alignment.Good, 0);
            You.SetAlignmentScore(Alignment.Neutral, 0);
            You.SetAlignmentScore(Alignment.Evil, 0);

            megaSentence += ConstructSentence(Alignment.Good);
            megaSentence += ConstructSentence(Alignment.Good);
            megaSentence += ConstructSentence(Alignment.Evil);
            megaSentence += ConstructSentence(Alignment.Evil);
            megaSentence += ConstructSentence(Alignment.Neutral);

            startScene.Prompt = megaSentence;
            startScene.NeutralChoice = ConstructSentence(Alignment.Neutral);
            startScene.BadChoice = ConstructSentence(Alignment.Evil);
            startScene.GoodChoice = ConstructSentence(Alignment.Good);
            
            return startScene;
        }

        public void EndAdventure()
        {

        }

        public Scene NextScene(string choice, Alignment alignmentOfChoice)
        {
            Scene nextScene = new Scene();
            string megaSentence = "";

            //for(int i = 0; i < You.GetAlignmentScore(Alignment.Good); i++)
            //{
            //    megaSentence += ConstructSentence(Alignment.Good);
            //}
            //for(int i = 0; i < You.GetAlignmentScore(Alignment.Neutral); i++)
            //{
            //    megaSentence += ConstructSentence(Alignment.Neutral);
            //}
            //for(int i = 0; i < You.GetAlignmentScore(Alignment.Evil); i++)
            //{
            //    megaSentence += ConstructSentence(Alignment.Evil);
            //}
            megaSentence += ConstructSentence(Alignment.Good);
            megaSentence += ConstructSentence(Alignment.Evil);
            megaSentence += ConstructSentence(Alignment.Good);
            megaSentence += ConstructSentence(Alignment.Evil);
            megaSentence += ConstructSentence(Alignment.Neutral);

            nextScene.Prompt = megaSentence;
            nextScene.NeutralChoice = ConstructSentence(Alignment.Neutral);
            nextScene.BadChoice = ConstructSentence(Alignment.Evil);
            nextScene.GoodChoice = ConstructSentence(Alignment.Good);
            return nextScene;
        }
    }
}
