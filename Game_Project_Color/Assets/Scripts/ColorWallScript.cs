using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWallScript : MonoBehaviour
{

    [SerializeField] Color newColor;
    void Start()
    {
        
        
        Renderer rend = transform.GetChild(0).GetComponent<Renderer>();
        rend.material.SetColor("_Color", newColor);
    }
    public Color GetColor()
    {
        return newColor;
    }
   
}
