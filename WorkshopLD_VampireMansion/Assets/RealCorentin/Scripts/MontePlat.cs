using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontePlat : MonoBehaviour
{
    [SerializeField]
    private Transform RDC;

    [SerializeField]
    private Transform Labo;

    [SerializeField]
    private Transform Etage1;

    [SerializeField]
    private Transform Etage2;

    [SerializeField]
    private UI_MontePlat montePlatUI;

    [SerializeField]
    private string descriptionInteraction = null;

    [SerializeField]
    private bool isInteracting = false;



    private PlayerInteract playerInteract = null;

    public void TeleportTo(Transform Destination, GameObject Player)
    {
        Player.transform.position = Destination.transform.position;
    }

    public void Interact(PlayerInteract player)
    {
        if(isInteracting == false)
        {
            montePlatUI.ShowMenu();

            playerInteract = player;

            isInteracting = true;
        }

        else
        {
            montePlatUI.HideMenu();

            playerInteract = null;

            isInteracting = false;
        }
    }

    public bool GetIsInteracting()
    {
        return isInteracting;
    }

    public void SetIsInteracting(bool set)
    {
        isInteracting = set;
    }

    public string GetDescriptionInteraction()
    {
        return descriptionInteraction;
    }

    public void TpToLabo()
    {
        CharacterController charaController = playerInteract.GetComponent<CharacterController>();
        charaController.enabled = false;

        charaController.transform.localPosition = Labo.transform.position;

        charaController.enabled = true;
    }

    public void TpToRDC()
    {
        CharacterController charaController = playerInteract.GetComponent<CharacterController>();
        charaController.enabled = false;

        playerInteract.transform.position = RDC.transform.position;
        charaController.enabled = true;
    }
    public void TpToEtage1()
    {
        CharacterController charaController = playerInteract.GetComponent<CharacterController>();
        charaController.enabled = false;

        playerInteract.transform.position = Etage1.transform.position;
        charaController.enabled = true;
    }
    public void TpToEtage2()
    {
        CharacterController charaController = playerInteract.GetComponent<CharacterController>();
        charaController.enabled = false;

        playerInteract.transform.position = Etage2.transform.position;
        charaController.enabled = true;
    }
}
