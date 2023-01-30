using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indice : MonoBehaviour
{
    [SerializeField]
    private string IndiceName;

    [SerializeField]
    private string DescriptionInteraction;

    public string GetIndiceName()
    {
        return IndiceName;
    }

    public string GetDescriptionInteraction()
    {
        return DescriptionInteraction;
    }
}
