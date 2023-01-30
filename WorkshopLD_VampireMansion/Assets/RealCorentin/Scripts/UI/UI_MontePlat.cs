using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MontePlat : MonoBehaviour
{
    [SerializeField]
    private GameObject seeMenu;
    [SerializeField]
    private MontePlat montePlat;

    [SerializeField]
    private PlayerInteract playerInteract;

    [SerializeField]
    private List<GameObject> buttonList = null;

    [SerializeField]
    private bool boolLabo = false;
    [SerializeField]
    private bool boolRDC = true;
    [SerializeField]
    private bool boolEtage1 = false;
    [SerializeField]
    private bool boolEtage2 = false;

    private void OnEnable()
    {
        playerInteract.onItemTaken.RemoveListener(playerInteract_onItemTaken);
        playerInteract.onItemTaken.AddListener(playerInteract_onItemTaken);
    }

    private void OnDisable()
    {
        playerInteract.onItemTaken.RemoveListener(playerInteract_onItemTaken);
    }

    private void playerInteract_onItemTaken(PlayerInteract player, string itemName)
    {
        UpdateItem(itemName);
    }

    public void ShowMenu()
    {
        seeMenu.SetActive(true);
    }

    public void HideMenu()
    {
        StopInteraction();
        seeMenu.SetActive(false);
    }

    public void StopInteraction()
    {
        montePlat.SetIsInteracting(false);
    }

    private void Update()
    {
        UpdateInput();
        UpdateVisual();
    }

    private void UpdateInput()
    {
        if (seeMenu.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) & boolLabo == true)
            {
                montePlat.TpToLabo();
                HideMenu();
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2) & boolRDC == true)
            {
                montePlat.TpToRDC();
                HideMenu();
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3) & boolEtage1 == true)
            {
                montePlat.TpToEtage1();
                HideMenu();
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4) & boolEtage2 == true)
            {
                montePlat.TpToEtage2();
                HideMenu();
            }
        }
    }

    private void UpdateVisual()
    {
        if(boolLabo == false)
        {
            buttonList[0].SetActive(false);
        }

        if(boolRDC == false)
        {
            buttonList[1].SetActive(false);
        }

        if (boolEtage1 == false)
        {
            buttonList[2].SetActive(false);
        }

        if (boolEtage2 == false)
        {
            buttonList[3].SetActive(false);
        }
    }

    private void UpdateItem(string itemName)
    {
        if(itemName == "MontePlat1")
        {
            boolLabo = true;
            boolEtage1 = true;

            buttonList[0].SetActive(true);
            buttonList[2].SetActive(true);
        }

        if (itemName == "MontePlat2")
        {
            boolEtage2 = true;

            buttonList[3].SetActive(true);
        }
    }
}
