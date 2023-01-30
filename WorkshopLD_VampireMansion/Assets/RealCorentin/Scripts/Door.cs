using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool unlocked = false;

    [SerializeField]
    private bool isOpen = false;

    [SerializeField]
    private MeshRenderer doorMeshRenderer;
    [SerializeField]
    private BoxCollider boxCollider;

    [SerializeField]
    private string KeyName;

    [SerializeField]
    private string DescriptionInteraction;

    public  void OpenDoor()
    {
        if(unlocked == true)
        {
            Debug.Log("open door");

            doorMeshRenderer.enabled = false;
            boxCollider.isTrigger = true;

            isOpen = true;
        }
    }

    public void CloseDoor()
    {
        if (unlocked == true)
        {
            Debug.Log("close door");

            doorMeshRenderer.enabled = true;
            boxCollider.isTrigger = false;

            isOpen = false;
        }
    }

    public bool GetUnlocked()
    {
        return unlocked;
    }

    public bool GetIsOpen()
    {
        return isOpen;
    }

    public void UnlockDoor()
    {
        unlocked = true;
    }

    public string GetKeyName()
    {
        return KeyName;
    }

    public string GetDescriptionInteraction()
    {
        return DescriptionInteraction;
    }
}
