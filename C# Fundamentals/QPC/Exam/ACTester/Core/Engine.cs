namespace ACTester.Core
{
    using System;
    using ACTester.Interfaces;
    using ACTester.UI;

    public class Engine
    {
        public Engine(IActionManager actionManager, IUserInterface userInterface)
        {
            this.ActionManager = actionManager;
            this.UserInterface = userInterface;
        }

        public Engine()
            : this(new ActionManager(), new ConsoleUserInterface())
        {
        }

        public IActionManager ActionManager { get; private set; }

        public IUserInterface UserInterface { get; private set; }

        public void Run()
        {
            while (true)
            {
                string line = this.UserInterface.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    var command = new Command(line);
                    string commandResult = this.ActionManager.ExecuteCommand(command);
                    this.UserInterface.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    this.UserInterface.WriteLine(ex.Message);
                }
            }
        }
    }
}
