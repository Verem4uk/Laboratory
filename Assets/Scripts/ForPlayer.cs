using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPlayer : MonoBehaviour
{
    CharacterController controller;
    Animator anim;
    float speedrotation = 2f;//скорость поворота
    float speedmove = 0.2f;//скорость передвижения
    bool intrigger1 = false;
    bool intrigger2 = false;
    float weight1 = 0;
    float weight2 = 0;
    GameObject doorhandle1;
    GameObject doorhandle2;
    GameObject maindoor;
   
   // int doorstates = 1;//1-закрыта, 2-открывается, 3- открыта, 4 - закрывается



    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 move = transform.position;
        move.z-=0.01f;
        transform.position = move;
       */
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x != 0)
        {
            transform.Rotate(0f, x * speedrotation, 0f);
        }
        if (z!=0)
        {
            Vector3 dir;
            //if (Input.GetKey(KeyCode.W)) dir = transform.TransformDirection(new Vector3(0f, 0f, z * speedmove));
            // else dir = transform.TransformDirection(new Vector3(0f, 0f, z * speedmove / 2));
            dir = transform.TransformDirection(new Vector3(0f, 0f, z * speedmove / 2));
            controller.Move(dir);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        
       
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Collider1")
        {
            intrigger1 = true;
            maindoor = other.transform.parent.gameObject;
            doorhandle1 = other.transform.parent.gameObject.GetComponent<DoorColliders>().doorhandle1;
            doorhandle2 = other.transform.parent.gameObject.GetComponent<DoorColliders>().doorhandle2;
        }
        if (other.name == "Collider2")
        {
            intrigger2 = true;
            maindoor = other.transform.parent.gameObject;
            doorhandle1 = other.transform.parent.gameObject.GetComponent<DoorColliders>().doorhandle1;
            doorhandle2 = other.transform.parent.gameObject.GetComponent<DoorColliders>().doorhandle2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Collider1") intrigger1 = false;
        if (other.name == "Collider2") intrigger2 = false;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("door"))
        {
            Vector3 pushdir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            rb.velocity = pushdir * 3;
        }
    }
    private void OnAnimatorIK()
    {
        if (doorhandle1 != null && doorhandle2 != null)
        {
            if (intrigger1)
            {
                //Debug.Log(weight1);
                if (weight1 <= 1) weight1 += 0.05f;
               // if (weight2 >= 0) weight2 -= 0.05f;
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight1);
                anim.SetIKPosition(AvatarIKGoal.RightHand, doorhandle1.transform.position);

            }
            
            if (intrigger2)
            {
                if (weight1 <= 1) weight1 += 0.05f;
                //if (weight2 >= 0) weight2 -= 0.05f;
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight1);
                anim.SetIKPosition(AvatarIKGoal.RightHand, doorhandle2.transform.position);

            }
            if(!intrigger1&&!intrigger2)
            {
                /*
                if (weight1 >= 0) weight1 -= 0.05f;
                if (weight2 <= 1) weight2 += 0.05f;
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight2);
                anim.SetIKPosition(AvatarIKGoal.RightHand, StartCube.transform.position);
                */
                if (weight1 >= 0) weight1 -= 0.05f;
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight1);
                anim.SetIKPosition(AvatarIKGoal.RightHand, doorhandle1.transform.position);
            }
        }
    }
}