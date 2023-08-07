using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

public class Joe : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
    }

    private DialogueSection Conversation()
    {
        string localName = "Joe";
        // Occupation tied to possible events.
        string occupation = "Plumber";

        Monologue fine = new Monologue(localName, "That's nice to hear. Have a nice day!");
        Monologue not_fine = new Monologue(localName, "That's too bad... hope it improves!");
        Monologue bad = new Monologue(localName, "Sorry to hear that.");

        Choices b = new Choices(localName, "How are you today?", ChoiceList(Choice("Fine", fine), Choice("Not so fine...", not_fine), Choice("Bad", bad)));
        
        Monologue a = new Monologue(localName, $"Good morning, I'm {localName}.", b);

        return a;
    }
}