using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : Entity
{
    public float Zombie_jumpRange;
    public Vector3 Zombie_Jump_Offset;
    /*zombie moves to car (done ), zombie jump to car when close enough
     * zombie suddenly moves to the car with jumping anim
     * zombie explosion after jump anim 
     * 
     */
    public override void Update()
    {
        base.Update();
        /* if (Input.GetKey(KeyCode.T))
         {
             Move();
             zombieJump();
         }*/
    }
    public void zombieJump()
    {
        if (distance < Zombie_jumpRange)//zombie close enough
        {
            
            transform.position = new Vector3(_target.transform.position.x- Zombie_Jump_Offset.x,
                _target.transform.position.y - Zombie_Jump_Offset.y,
                _target.transform.position.z - Zombie_Jump_Offset.z);
            Animator.SetTrigger("Jump Attack");//zombie jump to car
            
            Invoke("damage",3.8f );//zombie explosion when anim finished

        }
        
    }
    

    public override void Move()
    {
        if ((distance < Zombie_jumpRange) && CharacterController.isGrounded) {
            Velocity = new Vector3(Velocity.x, 15f, Velocity.z);
            speed = distance / 3.7f;
        }
            
        base.Move();

    }





}
