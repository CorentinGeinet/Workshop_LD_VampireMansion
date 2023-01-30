using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private bool CleChambreGalahad = false;

    [SerializeField]
    private bool SeringueAlice = false;

    [SerializeField]
    private bool CleCaveVin = false;

    [SerializeField]
    private bool CleChambreElizabeth = false;

    [SerializeField]
    private bool ClePetitJardin = false;

    [SerializeField]
    private bool CadavreElizabeth = false;

    public void AddItem(string itemName)
    {
        if (itemName == "CleChambreGalahad")
        {
            CleChambreGalahad = true;
        }

        if (itemName == "SeringueAlice")
        {
            SeringueAlice = true;
        }

        if (itemName == "CleCaveVin")
        {
            CleCaveVin = true;
        }

        if (itemName == "CleChambreElizabeth")
        {
            CleChambreElizabeth = true;
        }

        if(itemName == "ClePetitJardin")
        {
            ClePetitJardin = true;
        }

        if (itemName == "CadavreElizabeth")
        {
            CadavreElizabeth = true;
        }
    }

    public bool CheckForItem(string itemName)
    {
        if (itemName == "CleChambreGalahad")
        {
            return CleChambreGalahad;
        }

        else if(itemName == "SeringueAlice")
        {
            return SeringueAlice;
        }

        else if(itemName == "CleCaveVin")
        {
            return CleCaveVin;
        }

        else if(itemName == "CleChambreElizabeth")
        {
            return CleChambreElizabeth;
        }

        else if(itemName == "ClePetitJardin")
        {
            return ClePetitJardin;
        }

        else if (itemName == "CadavreElizabeth")
        {
            return CadavreElizabeth;
        }

        else
        {
            return false;
        }
    }
}
