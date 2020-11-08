using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStackColor : MonoBehaviour
{
    [SerializeField]
    int value;
    [SerializeField]
    Color _pickUpColor;
    void Start()
    {
        Renderer rend= GetComponent<Renderer>();
        rend.material.SetColor("_Color",_pickUpColor);
    }


    public Color GetColor()
    {
        return _pickUpColor;
    }
 
}
