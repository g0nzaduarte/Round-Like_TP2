using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandConsole : MonoBehaviour
{
    public TMP_InputField inputField; 
    public GameObject player;

    public void ProcessCommand()
    {
        string command = inputField.text;
        inputField.text = "/empty";

        switch (command.ToLower())
        {
            case "/help":
                Debug.Log("Available commands: /help, /speedy, /nuke, /clear.");
                break;

            case "/speedy":
                player.GetComponent<PlayerMovement>().speed *= 2;
                Debug.Log("Activated player double speed.");
                break;

            case "/nuke":
                var enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var enemy in enemies)
                {
                    Destroy(enemy);
                }
                Debug.Log("Destroyed enemies permanently.");
                break;


            case "/clear":
                player.GetComponent<PlayerMovement>().speed = 7;
                Debug.Log("Restored game back to normal.");
                break;

            default:
                Debug.Log("Can´t recognize this command.");
                break;
        }
    }
}

