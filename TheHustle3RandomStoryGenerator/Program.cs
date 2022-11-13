using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHustle3RandomStoryGenerator
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EntryForm form = new EntryForm();
            Controller controller = new Controller();
            form.StartAdventure = controller.StartAdventure;
            form.EndAdventure = controller.EndAdventure;
            form.NextScene = controller.NextScene;
            Application.Run(form);
        }
    }
}
