using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UI_Dialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject seeMenu;

    [SerializeField]
    private TextMeshProUGUI characterName;

    [SerializeField]
    private TextMeshProUGUI dialogueText;

    public UnityEvent<UI_Dialogue> onDialogueClosed;

    public void OpenMenu()
    {
        seeMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        seeMenu.SetActive(false);

        CleanDialogueUI();
    }

    public void SetCharacterName(string name)
    {
        characterName.text = name;
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }

    public void CleanDialogueUI()
    {
        characterName.text = null;
        dialogueText.text = null;
        seeMenu.SetActive(false);

        onDialogueClosed?.Invoke(this);
    }
}
