using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandConsole : MonoBehaviour
{
    public TMP_InputField inputField;
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public void AddCommand(string name, ICommand command)
    {
        if (!commands.ContainsKey(name))
        {
            commands.Add(name, command);
        }
    }

    public void ProcessCommand()
    {
        string commandName = inputField.text.ToLower();
        inputField.text = "Available commands: /speedy, /nuke";

        if (commands.TryGetValue(commandName, out ICommand command))
        {
            command.Execute();
        }
        else
        {
            Debug.Log("Command not recognized: " + commandName);
        }
    }

    void Start()
    {
        CommandConsole console = FindObjectOfType<CommandConsole>();
        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        console.AddCommand("/speedy", new SpeedCommand(player, 2f));
        console.AddCommand("/nuke", new NukeCommand());
    }

}

