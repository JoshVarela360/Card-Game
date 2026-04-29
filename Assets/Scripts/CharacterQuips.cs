using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] GameObject _dialogueBox;
    [SerializeField] TextMeshProUGUI _dialogueText;

    public void ShowDialogue(string text)
    {
        _dialogueBox.SetActive(true);
        _dialogueText.text = text;
    }

    public void HideDialogue()
    {
        _dialogueBox.SetActive(false);
        _dialogueText.text = "";

    }
}