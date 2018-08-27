using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REF : MonoBehaviour {

    public GameObject student;

    public void Event()
    {
        student.GetComponent<EthanMove>().AfterDoor();
    }
}
