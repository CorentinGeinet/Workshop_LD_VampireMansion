using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float interactRange = 10f;

    [SerializeField]
    private UI_Interact interactUI;
    [SerializeField]
    private UI_Dialogue dialogueUI;
    [SerializeField]
    private UI_MontePlat montePlatUI;

    [SerializeField]
    private PlayerInventory playerInventory;

    public UnityEvent<PlayerInteract, string> onItemTaken;

    private void Update()
    {
        Indice indice = GetIndice();
        Door door = GetDoor();
        NPC npc = GetNPC();
        MontePlat montePlat = GetMontePlat();
        PassageSecret passageSecret = GetPassageSecret();

        if (indice != null)
        {
            interactUI.ShowInteractUI();
            interactUI.SetDescription(indice.GetDescriptionInteraction());

            if (Input.GetKeyDown(KeyCode.E))
            {
                string indiceName = indice.GetIndiceName();
                playerInventory.AddItem(indiceName);

                onItemTaken?.Invoke(this, indiceName);

                Destroy(indice.gameObject);

                interactUI.HideInteractUI();
            }
        }

        else if(npc != null)
        {
            if (npc.GetIsInteracting() == false)
            {
                interactUI.ShowInteractUI();
                interactUI.SetDescription(npc.GetDescriptionInteraction());
            }
            else
            {
                interactUI.HideInteractUI();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                npc.Interact();

            }
        }

        else if(door != null)
        {
            interactUI.ShowInteractUI();
            interactUI.SetDescription(door.GetDescriptionInteraction());

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (door.GetUnlocked() == false)
                {
                    // door not unlocked yet 

                    string keyName = door.GetKeyName();
                    if (playerInventory.CheckForItem(keyName))
                    {
                        door.UnlockDoor();
                        door.OpenDoor();

                        Debug.Log("Door unlocked");
                    }

                    else
                    {
                        Debug.Log("porte bloqué");
                    }

                }

                else
                {
                    if (door.GetIsOpen() == false)
                    {
                        door.OpenDoor();
                    }
                    else
                    {
                        door.CloseDoor();
                    }
                }
            }
        }

        else if(montePlat != null)
        {
            if(montePlat.GetIsInteracting() == false)
            {
                interactUI.ShowInteractUI();
                interactUI.SetDescription(montePlat.GetDescriptionInteraction());
            }
            else
            {
                interactUI.HideInteractUI();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                montePlat.Interact(this);

            }
        }

        else if(passageSecret != null)
        {
            interactUI.ShowInteractUI();
            interactUI.SetDescription(passageSecret.getDescriptionText());

            passageSecret.Interact(this);
        }

        else
        {
            interactUI.HideInteractUI();
            dialogueUI.CleanDialogueUI();
            montePlatUI.HideMenu();
        }
    }

    public Indice GetIndice()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.transform.parent != null)
            {
                if (collider.transform.parent.TryGetComponent<Indice>(out Indice indice))
                {
                    return indice;
                }
            }
        }

        return null;
    }

    public Door GetDoor()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.transform.parent != null)
            {
                if (collider.transform.parent.TryGetComponent<Door>(out Door door))
                {
                    return door;
                }
            }
        }

        return null;
    }

    public NPC GetNPC()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.transform.parent != null)
            {
                if (collider.transform.parent.TryGetComponent<NPC>(out NPC npc))
                {
                    return npc;
                }
            }
        }

        return null;
    }

    public MontePlat GetMontePlat()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.transform.parent != null)
            {
                if (collider.transform.parent.TryGetComponent<MontePlat>(out MontePlat montePlat))
                {
                    return montePlat;
                }
            }
        }

        return null;
    }

    public PassageSecret GetPassageSecret()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.transform.parent != null)
            {
                if (collider.transform.parent.TryGetComponent<PassageSecret>(out PassageSecret passageSecret))
                {
                    return passageSecret;
                }
            }
        }

        return null;
    }
}
