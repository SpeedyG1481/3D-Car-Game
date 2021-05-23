using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Entity
{
    public Transform player;
    public GameObject enemy;
    public float moveSpeed, maxRange, minRange, jumpRange,jumpAmount;
    public Rigidbody rb;
    // Start is called before the first frame update
    public override void Start()
    {
        Player= FindObjectOfType<Vehicle>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
       
        if (Input.GetKey(KeyCode.T))
        {
            
        }
    }

    private void HandleMovement()
    {



        if (Distance(player, enemy) < maxRange)
        {
            var positionX = enemy.transform.position.x - player.position.x;



            if (minRange > Distance(player, enemy))
            {
                IsJumping = false;
                Debug.Log("down");
                Destroy(this);
                //Damage to car
            }

            else
            if (jumpRange > Distance(player, enemy) && !IsJumping)//jump
            {
                if (positionX < 0)
                {
                    Jump(rb, -5, jumpAmount, -1);
                }
                else if (positionX > 0) 
                {
                    Jump(rb, 5, jumpAmount, -1);
                }
                

                Debug.Log("jump");
            }
            else if (minRange < Distance(player, enemy))
            {
                Chase(Tracking(player, enemy), moveSpeed + Player.Speed/2, rb);
            }

        }
        else
        {
            //destroy enemy after a few munites

        }




        
    }
}
