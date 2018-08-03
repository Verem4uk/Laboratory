using UnityEngine;
using System.Collections;
public class ForCamera : MonoBehaviour
{
    
    //private Transform target;
    public float rotSpeed = 4f;
    private float _rotY = 0;
    private float _rotX = 0;

    void LateUpdate()
    {   
        _rotY += Input.GetAxis("Mouse Y") * rotSpeed;
        _rotX += Input.GetAxis("Mouse X") * rotSpeed;
        Quaternion rotation = Quaternion.Euler(-_rotY, _rotX, 0);
        transform.parent.transform.localRotation = rotation;
    }
}