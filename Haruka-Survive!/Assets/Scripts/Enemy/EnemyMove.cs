using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float chaseDistance = 5;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] Vector3 home;
    
    
    Animator Animator;
    public bool move;
    public bool moveless;

    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 moveDirection = playerPosition - transform.position;
       
        //if player is close
        if (moveDirection.magnitude < chaseDistance)
        {
            //chase player
            moveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;
            Animator.SetBool("move", true);
            Animator.SetBool("Idel", false);
        }
        else {
            moveDirection = home - transform.position;
            if (moveDirection.magnitude > 0.3)
            {
                moveDirection.Normalize();
                GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;

                Animator.SetBool("move", true);
                Animator.SetBool("Idel", false);
            } 
            else
            {
                
                transform.position = home;
               
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                Animator.SetBool("Idel", true);
                Animator.SetBool("move", false);
            }

        }
       
    }
  
}
