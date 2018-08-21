using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EthanMove : MonoBehaviour {

   public Animator dooranimator;
   private Transform target;
   Quaternion newrot;
    
   Animator anim;
   States state;
    // Use this for initialization

    enum States
    {
        wait,
        firstturn,
        walk,
        secondturn
    }
    
	void Start () {
      anim = GetComponent<Animator>();
      state = States.wait;
	}
	
	// Update is called once per frame
	void Update () {
        
        switch (state)
        {
            case States.firstturn:
            {
                    transform.rotation = Quaternion.Lerp(transform.rotation, newrot, Time.deltaTime);

                    print(newrot.y);
                    print(transform.rotation.y);
                    if (Mathf.Abs(Mathf.Round(newrot.y * 10)) == Mathf.Abs(Mathf.Round(transform.rotation.y * 10)))
                    {
                        print("повернулся");
                        transform.rotation = newrot;
                        state = States.walk;
                        anim.SetBool("Walk", true);                        
                    }
                    break;
            }
            case States.walk:
            {
                    transform.position = transform.position + transform.forward * Time.deltaTime;
                    
                    if (Vector3.Distance(transform.position, target.position) <= 0.5)
                    {
                        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
                        state = States.wait;
                        anim.SetBool("Walk", false);
                        print("дошел");
                        TurnToDoor();
                    }
                    break;

            }
            case States.secondturn:
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, newrot, Time.deltaTime);

                    if (Mathf.Abs(Mathf.Round(newrot.y * 10)) == Mathf.Abs(Mathf.Round(transform.rotation.y * 10)))
                    {
                        transform.rotation = newrot;
                        state = States.wait;
                        print("открываем");
                        dooranimator.SetTrigger("Open");
                        anim.SetTrigger("Open");                        
                    }

                    break;
                }
        }
             

    }
    public void GoToPoint (GameObject point)
    {
        print(state);
        if (state == States.wait)
        {
            anim.SetBool("Walk", false);
            target = point.transform;
            dooranimator = point.transform.parent.GetComponent<Animator>();
            Vector3 relativePos = new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position;
            newrot = Quaternion.LookRotation(relativePos);
            state = States.firstturn;
        }
    }
    void TurnToDoor()
    {
        Vector3 relativePos = new Vector3(target.position.x, transform.position.y, target.position.z - 1) - transform.position;
        newrot = Quaternion.LookRotation(relativePos);
        state = States.secondturn;
    }

  
}
