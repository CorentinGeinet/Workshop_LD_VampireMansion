using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private UI_Inventory inventoryUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.GetIsOpened() == false)
            {
                inventoryUI.OpenMenu();
            }
            else
            {
                inventoryUI.CloseMenu();
            }
        }
    }
}
