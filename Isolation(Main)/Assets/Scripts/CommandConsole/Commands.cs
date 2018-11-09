using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    //-----------------------------------------------------------------------------------------------------------------------------------------//
    // COMMAND INFO:                                                                                                                           //
    //                                                                                                                                         //
    // To make your own command, duplicate the test command found below. The important things are marked with a *.                             //
    // You will then have to go into the "DeveloperConsole" script and find the "CreateCommands" function. Further instructions are there      //
    //                                                                                                                                         //
    // You can find information about how the console is setup in the DeveloperConsole script.                                                 //
    //                                                                                                                                         //
    // If you want to access something in the DeveloperConsole script, make sure you put "DeveleporConsole." before any functions/variables.   //
    //-----------------------------------------------------------------------------------------------------------------------------------------// 



    public class TestCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string CommandText { get; protected set; }

        public TestCommand()
        {
            // *The name of the command
            Name = "Test Command";

            // *What the user needs to type into the console in order for the command to be executed. At the moment, the commands cannot take arguements (so keep them as one word)
            CommandText = "testcommand";

            AddCommandToConsole();
        }
        
        // *This function is where all the code for the command is stored. In this example, the command prints a message to the console.
        public override void RunCommand()
        {
            DeveloperConsole.AddMessageToConsole("This is a test command. It is has been succesfully created!");
        }

        // *Very important. Make sure you put the the name of the command's class in the same spots "TestCommand" is!
        // Example:
        // 
        // public static YourCommand CreateCommand()
        // {
        //     return new YourCommand();
        // {

        public static TestCommand CreateCommand()
        {
            return new TestCommand();
        }
    }
}
