using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [Header("UI Setting")]
    public TextMeshProUGUI dialogText; // Reference to the Text UI element
    public TextMeshProUGUI characterText; // Reference to the Text UI element

    public GameObject DialogPanal;

    [Header("Choice Setting")]
    public GameObject choiceGameObject;
    public GameObject choicePanel; // Reference to the Choice Panel
    public GameObject buttonPrefab; // Prefab for the choice button

    [Header("Sound Setting")]
    public AudioClip BackgroundMusic; // Background music clip
    private AudioSource audioSource; // AudioSource component
    public AudioClip TypeSound; // Background music clip

    [Header("Background Setting")]
    public Image BackgroundUI;

    [Header("Dialog Setting")]
    public DialogInfoSO dialogData; // Reference to the DialogData ScriptableObject
    public float typingSpeed = 0.05f; // Speed at which the text is revealed

    // Private variable area
    private int currentDialogIndex = 0;
    private Coroutine typingCoroutine;

    //need to setup instant when scene start
    public void SetNewDialog(DialogInfoSO dialogData)
    {
        this.dialogData = dialogData;
        currentDialogIndex = 0;
    }

    void Awake()
    {
       
    }

    void Start()
    {
        // Get or add the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the AudioSource's clip to BackgroundMusic and play it
        if (BackgroundMusic != null)
        {
            audioSource.clip = BackgroundMusic;
            audioSource.loop = true; // Optional: make the music loop
            audioSource.Play();
        }

        if (dialogData != null)
        {
            if (dialogData.DialogType == DialogType.Boxtype)
            {
                DisplayDialog(currentDialogIndex);
            }
            else Debug.LogWarning("This chat data is NOT Box dialog type"); 
        }

        if (BackgroundMusic != null)
        {
            audioSource.clip = BackgroundMusic;
            audioSource.loop = true;
            audioSource.Play(); // ← optional, skip if you only want to play background between dialogs
        }

    }

    public void DisplayDialog(int index)
    {
        if (index >= 0 && index < dialogData.dialogEntries.Count)
        {
            DialogEntry entry = dialogData.dialogEntries[index];

            characterText.text = entry.characterData.GetName();

            if (entry.BackgroundImage != null) BackgroundUI.sprite = entry.BackgroundImage; //set Background Image

            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeText(entry.text));          
           
        }
    }

    private void GenerateChoices()
    {
        // Clear previous choices
        foreach (Transform child in choicePanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Create buttons for each choice
        foreach (DialogChoice choice in dialogData.dialogChoices)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, choicePanel.transform);
            Button button = buttonObject.GetComponent<Button>();
            Text buttonText = buttonObject.GetComponentInChildren<Text>();

            if (buttonText != null)
            {
                buttonText.text = choice.text; // Set the button text to match the dialog choice text
            }

            // Set the click event
            button.onClick.AddListener(() => OnChoiceSelected(choice));
        }
    }

    private void OnChoiceSelected(DialogChoice choice)
    {
        // Check if the choice has a NextDialog assigned
        if (choice.NextDialog != null)
        {
            // Set the current dialogData to the next dialog in the choice
            dialogData = choice.NextDialog;
            currentDialogIndex = 0;

            // Hide choice buttons
            choicePanel.SetActive(false);
            choiceGameObject.SetActive(false);

            // Display the first dialog entry in the new dialogData
            DisplayDialog(currentDialogIndex);
        }
        else
        {
            Debug.LogWarning("NextDialog is not set for this choice.");
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialogText.text = "";

        if (TypeSound != null)
        {
            audioSource.clip = TypeSound;
            audioSource.loop = true;
            audioSource.Play();
        }

        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Optionally resume background music
        if (BackgroundMusic != null)
        {
            audioSource.clip = BackgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }


    // Call this method to proceed to the next dialog entry
    public void NextDialog()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;

            if (audioSource.isPlaying)
                audioSource.Stop();

            // Optionally resume background music
            if (BackgroundMusic != null)
            {
                audioSource.clip = BackgroundMusic;
                audioSource.loop = true;
                audioSource.Play();
            }
        }

        currentDialogIndex++;
        if (currentDialogIndex < dialogData.dialogEntries.Count)
        {
            DisplayDialog(currentDialogIndex);
        }
        else
        {
            // End of dialog entries, show dialog choices if available
            if (dialogData.dialogChoices != null && dialogData.dialogChoices.Count > 0)
            {
                GenerateChoices();
                choicePanel.SetActive(true); // Show the choice panel
                choiceGameObject.SetActive(true);
            }
            else
            {
                Debug.Log("End of dialog.");
                DialogPanal.SetActive(false);

                //SceneManager.LoadScene(0); // To go Back into Minimap Scene

            }
        }
    }
}
