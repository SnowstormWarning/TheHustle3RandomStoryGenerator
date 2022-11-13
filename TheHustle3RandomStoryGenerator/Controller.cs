using System;
using System.Collections.Generic;
using System.Text;

namespace TheHustle3RandomStoryGenerator
{
    class Controller
    {
        public List<Word> Words;
        public List<Noun> Nouns;
        public List<Adjective> Adjectives;
        public List<Verb> Verbs;
        public List<Character> Characters;

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
                predicate += nouns[random.Next(verbs.Count)].ToString()+" ";
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
        public Scene StartAdventure(List<Character> characters)
        {
            Scene startScene = new Scene();
            string megaSentence = "";
            foreach (Character person in characters)
            {
                megaSentence += ConstructSentence(person.GetAlignment());
            }
            startScene.Prompt = "Yes";
            startScene.NeutralChoice = "Neutral";
            startScene.BadChoice = "Bad";
            startScene.GoodChoice = "Good";
            return startScene;
        }

        public void EndAdventure()
        {

        }

        public Scene NextScene(string choice, Alignment alignmentOfChoice)
        {
            Scene nextScene = new Scene();
            nextScene.Prompt = "Words";
            nextScene.NeutralChoice = "Neutral";
            nextScene.BadChoice = "Bad";
            nextScene.GoodChoice = "Good";
            return nextScene;
        }


    }
}
