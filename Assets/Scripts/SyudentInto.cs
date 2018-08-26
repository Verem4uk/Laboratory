using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyudentInto : MonoBehaviour {

    Animator anim;
    public Animator dooranimator;
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Open");
        dooranimator.SetTrigger("Open");
	}
	
}
