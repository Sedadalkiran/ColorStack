using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region variable
    [SerializeField] Color Mycolor;
    [SerializeField] Renderer[] playerenderers;
    [SerializeField] bool isPlaying;
    [SerializeField] float FSpeed;
    [SerializeField] float sideLerpSpeed;
    Rigidbody RB;
    Transform parentPickup;
    [SerializeField] Transform stackPosition;
    #endregion

    void Start()
    {
       
        RB = GetComponent<Rigidbody>();
        SetColor(Mycolor);
    }


    void Update()
    {
        if (isPlaying)
        {
            MoveForward();
        }
        if (Input.GetMouseButton(0))
        {
            if (isPlaying == false)
            {
                isPlaying = true;
            }
            MoveSideWays();
        }
    }

    void SetColor(Color color_p)
    {
        Mycolor = color_p;
        for (int i = 0; i < playerenderers.Length; i++)
        {
            playerenderers[i].material.SetColor("_Color", Mycolor);
        }
    }

    void MoveForward()
    {
        RB.velocity = Vector3.forward * FSpeed;
    }
    void MoveSideWays()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), sideLerpSpeed * Time.deltaTime);
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            SetColor(Mycolor);
            int countStack = stackPosition.childCount;
            Debug.Log(countStack);
            Transform otherTransform = other.transform;
            Debug.Log(otherTransform);
            Rigidbody otherRigidbody = otherTransform.GetComponent<Rigidbody>();
            otherRigidbody.isKinematic = true;
            other.enabled = false;
            if (Mycolor== otherTransform.GetComponent<PickUpStackColor>().GetColor())
            {
                if (parentPickup == null & countStack < 1)
                {
                    parentPickup = otherTransform;
                    parentPickup.position = stackPosition.transform.position;
                    parentPickup.parent = stackPosition.transform;
                }
                if (parentPickup != null & countStack >= 1)
                {


                    otherTransform.position = stackPosition.position + new Vector3(0, countStack, 0) * (other.transform.localScale.y);
                    otherTransform.parent = stackPosition;




                }
            }
            else 
            {
               
               
                if (countStack > 1)
                {
                    Destroy(other.gameObject);
                    Destroy(stackPosition.GetChild(stackPosition.childCount-1).gameObject);
                    Debug.Log("silindi");

                }
                else 
                {
                    if (parentPickup != null)
                    {
                        Destroy(parentPickup.gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ColorWall")
        {
            SetColor(other.GetComponent<ColorWallScript>().GetColor());
        }
    }
}
