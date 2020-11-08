using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region variable
    [SerializeField] Transform target;
    float distance;
   
    #endregion

    void Start()
    {
        
        distance =transform.position.z -target.position.z;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + distance);
    }
}
