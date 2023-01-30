using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private string npcName;

    [SerializeField]
    private string descriptionInteraction;

    [SerializeField]
    private List<string> dialogueList;

    [SerializeField]
    private UI_Dialogue dialogueUI;

    private int dialogueIndex = 0;

    private bool isInteracting = false;

    private void Start()
    {
        //dialogueList = new List<string>();
    }

    private void OnEnable()
    {
        dialogueUI.onDialogueClosed.RemoveListener(dialogueUI_onDialogueClosed);
        dialogueUI.onDialogueClosed.AddListener(dialogueUI_onDialogueClosed);
    }

    private void OnDisable()
    {
        dialogueUI.onDialogueClosed.RemoveListener(dialogueUI_onDialogueClosed);
    }

    private void dialogueUI_onDialogueClosed(UI_Dialogue dialogueUI)
    {
        CleanNpcDialogue();
    }

    public string GetDescriptionInteraction()
    {
        return descriptionInteraction;
    }

    public bool GetIsInteracting()
    {
        return isInteracting;
    }

    public void Interact()
    {
        if(isInteracting == false)
        {
            InitializeDialogue();
            isInteracting = true;
        }
        else
        {
            if (TryNextDialogue() == false)
            {
                dialogueUI.CloseMenu();
                isInteracting = false;
            }
        }
    }

    public string GetNpcName()
    {
        return npcName;
    }

    public void InitializeDialogue()
    {
        dialogueUI.OpenMenu();

        dialogueUI.SetCharacterName(npcName);
        dialogueUI.SetDialogueText(dialogueList[0]);
    }

    public bool TryNextDialogue()
    {
        dialogueIndex++;

        if(dialogueIndex < dialogueList.Count)
        {
            dialogueUI.SetDialogueText(dialogueList[dialogueIndex]);
            return true;
        }
        else
        {
            //plus de dialogue à dire

            return false;
        }
    }

    public void CleanNpcDialogue()
    {
        dialogueIndex = 0;
        isInteracting = false;
    }
}
