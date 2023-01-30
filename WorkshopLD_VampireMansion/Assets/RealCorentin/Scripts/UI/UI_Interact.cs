using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Interact : MonoBehaviour
{
    [SerializeField]
    private GameObject seeMenu;

    [SerializeField]
    private TextMeshProUGUI descriptionText = null;

    public void ShowInteractUI()
    {
        seeMenu.SetActive(true);
    }

    public void HideInteractUI()
    {
        seeMenu.SetActive(false);
    }

    public void SetDescription(string description)
    {
        descriptionText.text = description;
    }
}
