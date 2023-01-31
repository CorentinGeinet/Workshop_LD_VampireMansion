using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageSecret : MonoBehaviour
{
    [SerializeField]
    private Transform teleportPoint;

    [SerializeField]
    private string descriptionText;

    public void Interact(PlayerInteract playerInteract)
    {
        PlayerController playerController = playerInteract.GetComponent<PlayerController>();
        /*playerController.enabled = false;

        playerInteract.transform.position = teleportPoint.transform.position;

        playerController.enabled = true;*/

        playerInteract.gameObject.SetActive(false);
        playerInteract.transform.position = teleportPoint.transform.position;
        playerInteract.gameObject.SetActive(true);

    }

    public string getDescriptionText()
    {
        return descriptionText;
    }
}
