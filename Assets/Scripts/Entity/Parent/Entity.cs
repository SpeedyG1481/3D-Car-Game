using System;
using UnityEngine;
public class Entity : MonoBehaviour
{
    private Vehicle _player;
    private float _health;
    protected static bool IsChasing, IsJumping, IsShotting;

    public virtual void Start()
    {

    }
    public Vehicle Player
    {
        get { return _player; }
        set { _player = value; } 
    }
    public float Health
    {
        get { return _health; }
    }

    public float Distance(Transform player,GameObject enemy)
    {
        float dist = Vector3.Distance(player.position, enemy.transform.position);

        return dist;
    }

    public  Vector3 Tracking(Transform player,GameObject enemy)
    {
        Vector3 direction = player.position - enemy.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.transform.LookAt(player);
        direction.Normalize();
        return direction;
    }


   public void Chase(Vector3 direction,float moveSpeed,Rigidbody rb)
    {
        rb.MovePosition((Vector3)transform.position + (direction * moveSpeed * Time.deltaTime));
        IsChasing = true;
    }
    public void Jump(Rigidbody rb,float amountX, float amountY,float amountZ,string position)
    {
        
        if (position == "right") 
        {
            Debug.Log("right");
            rb.velocity += _player.transform.right * -amountX + Vector3.up * amountY + _player.transform.forward * amountZ;
        }
        else if(position == "left")
        {
            Debug.Log("left");
            rb.velocity += _player.transform.right * amountX + Vector3.up * amountY + _player.transform.forward * amountZ;
        }
        IsJumping = true;
    }
    void Shotting()
    {
        IsShotting = true;
    }

}
