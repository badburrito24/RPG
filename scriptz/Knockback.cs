using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public string tag;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {

        //if tag is enemy or player
       // if (tag == "enemy" && !other.CompareTag("bullet"))
       // {
           if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
           {
                // if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("bullet"))
                //Get rigid body
                Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
                //if rigid body is not null
                if (hit != null)
                {
                    //calculate the difference, multiply it by the thrust, and add force to the object]

                    Vector2 difference = hit.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    hit.AddForce(difference, ForceMode2D.Impulse);

                    //if it's an enemy, stagger it
                    if (other.gameObject.CompareTag("enemy") && other.isTrigger)
                    {
                        // Debug.Log("enemy hit");
                        hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                        other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                    }
                    //if it's the player, stagger them and start their knockback 
                    if (other.gameObject.CompareTag("Player"))
                    {
                        if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                        {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                        }
                    }
                }

           }
            if (other.gameObject.CompareTag("breakable"))
            {
                if (tag == "drill" && tag != "bullet")
                {

                other.GetComponent<crystal>().Crack();


                }
                else
                {
                other.GetComponent<pot>().Smash();
                }
            }
    }
}

