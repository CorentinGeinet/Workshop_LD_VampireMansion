using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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

    [SerializeField]
    private GameObject player;



    private PlayerInteract playerInteract = null;

    public void TeleportTo(Transform Destination, GameObject Player)
    {
        Player.transform.position = Destination.transform.position;
    }

    public void Interact(PlayerInteract player)
    {
        if(isInteracting == false)
        {
            montePlatUI.ShowMenu(this);

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
        CharacterController charaController = player.GetComponent<CharacterController>();
        charaController.enabled = false;

        player.transform.position = Labo.transform.position;

        charaController.enabled = true;
    }

    public void TpToRDC()
    {
        CharacterController charaController = player.GetComponent<CharacterController>();
        charaController.enabled = false;

        player.transform.position = RDC.transform.position;
        charaController.enabled = true;
    }
    public void TpToEtage1()
    {
        CharacterController charaController = player.GetComponent<CharacterController>();
        charaController.enabled = false;

        player.transform.position = Etage1.transform.position;
        charaController.enabled = true;
    }
    public void TpToEtage2()
    {
        CharacterController charaController = player.GetComponent<CharacterController>();
        charaController.enabled = false;

        player.transform.position = Etage2.transform.position;
        charaController.enabled = true;
    }
}
