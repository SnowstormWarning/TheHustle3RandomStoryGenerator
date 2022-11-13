using System;
using System.Collections.Generic;
using System.Text;

namespace TheHustle3RandomStoryGenerator
{
    public delegate Scene StartAdventure();
    public delegate void EndAdventure();
    public delegate Scene NextScene(string choice, Alignment alignment);
}
