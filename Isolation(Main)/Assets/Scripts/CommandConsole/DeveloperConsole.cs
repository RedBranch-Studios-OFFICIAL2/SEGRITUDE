//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//namespace Console
//{
//    The class that all commands inherit.More information on this can be found in the "Commands" script
//    public abstract class ConsoleCommand
//    {
//        public abstract string Name { get; protected set; }
//        public abstract string CommandText { get; protected set; }

//        public void AddCommandToConsole()
//        {
//            Adds command to the list of commands
//            DeveloperConsole.AddCommandsToConsole(CommandText, this);
//            Prints in the console that it has done this
//            DeveloperConsole.AddMessageToConsole(Name + " has been added to the console");
//        }

//        Runs the code the command is supposed to execute
//        public abstract void RunCommand();
//    }

//    public class DeveloperConsole : MonoBehaviour
//    {
//        This makes it so the console can be accessed by any class
//        public static DeveloperConsole instance;
//        This dictionary stores a list of commands(The key is a string which is what the user needs to input into the console and the value is the corresponding command)
//        public static Dictionary<string, ConsoleCommand> Commands { get; protected set; }

//        Variables to access the UI of the console
//       [Header("UI Components")]
//        public Canvas consoleCanvas;
//        public InputField consoleInput;
//        public Text inputText;
//        public Text consoleText;

//        private void Awake()
//        {
//            if (instance != null)
//            {
//                return;
//            }

//            instance = this;
//            Commands = new Dictionary<string, ConsoleCommand>();
//        }

//        Use this for initialization
//        private void Start()
//        {
//            Deactivates console by default
//            consoleCanvas.gameObject.SetActive(false);

//            CreateCommands();
//        }

//        Update is called once per frame
//        private void Update()
//        {
//            if (Input.GetKeyDown(KeyCode.BackQuote))
//            {
//                consoleCanvas.gameObject.SetActive(!consoleCanvas.gameObject.activeInHierarchy);
//            }

//            if (consoleCanvas.gameObject.activeInHierarchy)
//            {
//                if (Input.GetKeyDown(KeyCode.Return))
//                {
//                    if (inputText.text != "")
//                    {
//                        AddMessageToConsole(inputText.text);
//                        ParseInput(inputText.text);
//                    }
//                }
//            }
//        }

//         *Make sure you copy this line for any command that you create(i.e YourCommand.CreateCommand();)
//        public void CreateCommands()
//        {
//            TestCommand.CreateCommand();
//        }

//        Adds commands to the dictionary
//        public static void AddCommandsToConsole(string _name, ConsoleCommand _command)
//        {
//            if (!Commands.ContainsKey(_name))
//            {
//                Commands.Add(_name, _command);
//            }
//        }

//        A way to display a message in console.Uses the instance so that other objects can access this function
//        public static void AddMessageToConsole(string msg)
//        {
//            DeveloperConsole.instance.consoleText.text += "\n" + msg;
//        }

//        Takes in any text in the Input Field when return is pressed and checks if it is an actual command
//        private void ParseInput(string _inputText)
//        {
//            This here makes sure that if there are any spaces in what the user has entered, it will only check the first part(eventually will also be used for checking arguements)
//                string[] inputText = _inputText.Split(null);

//            if (inputText.Length == 0 || inputText == null)
//            {
//                AddMessageToConsole("Command not found");
//                return;
//            }

//            if (!Commands.ContainsKey(inputText[0]))
//            {
//                AddMessageToConsole("Command not found");

//                return;
//            }
//            else
//            {
//                Commands[inputText[0]].RunCommand();
//            }
//        }
//    }
//}