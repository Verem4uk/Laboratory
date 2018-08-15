using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EthanMove : MonoBehaviour {

   
   private Vector3 target;
   // private Vector3 target_pos = new Vector3(0,0,0);
    Quaternion look;
    Transform door;
  // private Vector3 direction;

   NavMeshAgent nav;
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
      nav = GetComponent<NavMeshAgent>();
      state = States.wait;
	}
	
	// Update is called once per frame
	void Update () {
       
        switch (state)
        {
            case States.firstturn:
            {
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, look, Time.deltaTime * 2);
                    
                    if (Mathf.Abs((Mathf.Abs(look.y) - Mathf.Abs(transform.rotation.y))) < 0.01)
                    {
                        state = States.walk;
                        anim.SetBool("Walk", true);
                        nav.SetDestination(target);
                        nav.speed = 2;
                        print("могу идти");
                    }

                    break;
            }
            case States.walk:
            {
                    if (Vector3.Distance(transform.position, target) < 0.5)
                    {
                        state = States.wait;
                        anim.SetBool("Walk", false);
                        print("дошел");
                        state = States.secondturn;
                        TurnToDoor(door);
                    }
                    break;

            }
            case States.secondturn:
                {
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, look, Time.deltaTime * 2);

                   if (Mathf.Abs((Mathf.Abs(look.y) - Mathf.Abs(transform.rotation.y))) < 0.005)
                    {
                        transform.LookAt(door);
                        state = States.wait;
                        anim.SetTrigger("Open");
                        print("включаем анимацию");
                    }
                    
                    break;
                }
        }
             

    }
    public void GoToPoint (GameObject point)
    {
        if (state == States.wait)
        {
            anim.SetBool("Walk", false);
            nav.speed = 0;
            print("поворачиваюсь");
            target = point.transform.position;
            door = point.transform.parent;
            var direction = (target - transform.position).normalized;
            look = Quaternion.LookRotation(direction);
            state = States.firstturn;
        }
    }
    void TurnToDoor(Transform door)
    {
        var direction = (door.transform.position - transform.position).normalized;
        look = Quaternion.LookRotation(direction);

    }

  
}
