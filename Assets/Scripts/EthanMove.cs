﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                    if (Mathf.Abs(Mathf.Round(newrot.y * 100)) == Mathf.Abs(Mathf.Round(transform.rotation.y * 100)))
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

                    if (Mathf.Abs(Mathf.Round(newrot.y * 200)) == Mathf.Abs(Mathf.Round(transform.rotation.y * 200)))
                    {
                        transform.rotation = newrot;
                        state = States.wait;
                        print("открываем");
                        StartCoroutine(EnterDoor());         
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
        //target.transform.localPosition = target.transform.forward;
        //Vector3 forwardz = target.transform.localPosition + target.transform.forward;
        //target.localPosition = target.transform.forward;
        Vector3 forward = target.transform.position + target.transform.right;
        Vector3 relativePos = new Vector3(forward.x, transform.position.y, forward.z) - transform.position;
        //target.localPosition = relativePos;
        newrot = Quaternion.LookRotation(relativePos);
        state = States.secondturn;
    }
    IEnumerator EnterDoor()//корутина ожидания
    {
        dooranimator.SetTrigger("Open");
        anim.SetTrigger("Open");        
        yield return new WaitForSeconds(3f);//ждем 3 секунды               
        // DontDestroyOnLoad(transform.gameObject); 
        SceneManager.LoadScene("1", LoadSceneMode.Single);

    }

}
