using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EthanMove : MonoBehaviour {

   private bool move = false;
   private Vector3 target;
    Quaternion look;
  // private Vector3 direction;

    NavMeshAgent nav;
   Animator anim;
   States state;
    // Use this for initialization

    enum States
    {
        wait,
        turn,
        walk
    }
    
	void Start () {
      anim = GetComponent<Animator>();
      nav = GetComponent<NavMeshAgent>();
      state = States.wait;
	}
	
	// Update is called once per frame
	void Update () {
        if (state==States.walk)
        {            
            if (Vector3.Distance(transform.position, target) < 0.5)
            {
                state = States.wait;
                anim.SetBool("Walk", false);
                print("дошел");               
            }
            
        }
        if(state==States.turn)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, look, Time.deltaTime*2);
            print(look.y);
            print(transform.rotation.y);
            if (Mathf.Abs((Mathf.Abs(look.y) - Mathf.Abs(transform.rotation.y))) < 0.02)
            {
                state = States.walk;
                anim.SetBool("Walk", true);
                nav.SetDestination(target);
                nav.speed = 2;
                print("могу идти");
            }
        }
        
    }
    public void GoToPoint (GameObject point)
    {
        anim.SetBool("Walk", false);
        nav.speed = 0;
        print("поворачиваюсь");
        target = point.transform.position;
        var direction = (target - transform.position).normalized;
        look = Quaternion.LookRotation(direction);
        state = States.turn;
        
    }

  
}
