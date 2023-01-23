using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject indice1;

    [SerializeField]
    private GameObject indice2;

    [SerializeField]
    private GameObject indice3;

    [SerializeField]
    private GameObject indice4;

    [SerializeField]
    private GameObject indice5;

    [SerializeField]
    private PlayerInteract playerInteract;

    [SerializeField]
    private GameObject seeMenu;

    private bool isOpened = false;

    private void OnEnable()
    {
        playerInteract.onItemTaken.RemoveListener(playerInteract_onItemTaken);
        playerInteract.onItemTaken.AddListener(playerInteract_onItemTaken);
    }

    private void OnDisable()
    {
        playerInteract.onItemTaken.RemoveListener(playerInteract_onItemTaken);
    }

    private void playerInteract_onItemTaken(PlayerInteract sender, string itemName)
    {
        UpdateUI(itemName);
    }

    public void OpenMenu()
    {
        seeMenu.SetActive(true);

        isOpened = true;
    }

    public void CloseMenu()
    {
        seeMenu.SetActive(false);

        isOpened = false;
    }

    public bool GetIsOpened()
    {
        return isOpened;
    }

    private void UpdateUI(string itemName)
    {
        if (itemName == "CleChambreGalahad")
        {
            indice1.SetActive(true);
        }

        else if (itemName == "SeringueAlice")
        {
            indice2.SetActive(true);
        }

        else if (itemName == "CleCaveVin")
        {
            indice3.SetActive(true);
        }

        else if (itemName == "CleChambreElizabeth")
        {
            
        }

        else if (itemName == "ClePetitJardin")
        {
            indice4.SetActive(true);
        }

        else if (itemName == "CadavreElizabeth")
        {
            indice5.SetActive(true);
        }
    }
}
