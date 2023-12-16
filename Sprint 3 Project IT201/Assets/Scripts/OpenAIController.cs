using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class OpenAIController : MonoBehaviour
{
    public TMP_Text textField;
    public TMP_InputField inputField;
    public Button okButton;
    public GameObject petKnight;
    public GameObject okButtonText;
    public GameObject Player;
    public NavMeshAgent petKnightAgent;
    private OpenAIAPI api;
    private List<ChatMessage> messages;

    // Start is called before the first frame update
    void Start()
    {
        // This line gets your API key (and could be slightly different on Mac/Linux)
        api = new OpenAIAPI("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");
        api = new OpenAIAPI("YOUR_KEY_HERE");

        StartConversation();
        okButton.onClick.AddListener(() => GetResponse());

        // Add listener for Enter key press in the input field
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);

        // Hide UI when not in use
        textField.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        okButton.gameObject.SetActive(false);

        // Disable petKnight movement till it agrees to work with player
        petKnightAgent.enabled = !petKnightAgent.enabled;
    }

    private void OnInputFieldEndEdit(string text)
    {
        // Check for enter key press and check if player is close enough to petKnight
        if (Input.GetKey(KeyCode.Return) && Vector3.Distance(Player.transform.position,petKnight.transform.position) < 10)
        {
            // If Enter is pressed, trigger the OK button click
            GetResponse();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for "/" key press to focus on the input field
        if (Input.GetKeyDown(KeyCode.Slash) && Vector3.Distance(Player.transform.position,petKnight.transform.position) < 10)
        {
            inputField.Select();
            inputField.ActivateInputField();
        }

        if (Vector3.Distance(Player.transform.position,petKnight.transform.position) < 10) {
            textField.gameObject.SetActive(true);
            inputField.gameObject.SetActive(true);
            okButton.gameObject.SetActive(true);
        }
        else {
            textField.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);
            okButton.gameObject.SetActive(false);
        }
    }

    private void StartConversation()
    {
        messages = new List<ChatMessage> {
            new ChatMessage(ChatMessageRole.System, "You are an honorable, friendly slime who is open to working with new adventurers. You will only work for someone who has defeated the Slime King. You will not work for anyone who has not yet defeated the Slime King. You keep your responses short and to the point. THIS IS VERY IMPORTANT: If you agree to work for someone, you will say exactly this: 'I will work for you, noble adventurer! Let's go out and clear the three camps of enemies!'. Do not say ANYTHING besides this exact statement if you agree to work for someone.")
        };

        inputField.text = "";
        string startString = "You have just approached the only friendly slime in the village. To start typing, press '/'. To send your message, press enter.";
        textField.text = startString;
        Debug.Log(startString);
    }

    private async void GetResponse()
    {
        if (inputField.text.Length < 1)
        {
            return;
        }

        // Disable the OK button
        okButton.enabled = false;

        // Fill the user message from the input field
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = inputField.text;
        if (userMessage.Content.Length > 100)
        {
            // Limit messages to 100 characters
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }
        Debug.Log(string.Format("{0}: {1}", userMessage.rawRole, userMessage.Content));

        // Add the message to the list
        messages.Add(userMessage);

        // Update the text field with the user message
        textField.text = string.Format("You: {0}", userMessage.Content);

        // Clear the input field
        inputField.text = "";

        // Send the entire chat to OpenAI to get the next message
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.9,
            MaxTokens = 100,
            Messages = messages
        });

        // Get the response message
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.rawRole, responseMessage.Content));

        // Check if the guard's message exactly matches the desired string
        if (responseMessage.Content == "I will work for you, noble adventurer! Let's go out and clear the three camps of enemies!")
        {
            // Allow slime to move!
            petKnightAgent.enabled = !petKnightAgent.enabled;

            // Clear out UI
            Destroy(textField, 5);
            Destroy(inputField, 5);
            Destroy(inputField.image,5);
            Destroy(okButton, 5);
            Destroy(okButton.image,5);
            Destroy(inputField.placeholder,5);
            Destroy(okButtonText,5);


            //THE BUTTON AND INPUTFIELD STILL APPEAR BUT TEXTFIELD GOES AWAY
        }


        // Add the response to the list of messages
        messages.Add(responseMessage);

        // Update the text field with the response
        textField.text = string.Format("You: {0}\n\nSlime: {1}", userMessage.Content, responseMessage.Content);

        // Re-enable the OK button
        okButton.enabled = true;
    }
}