using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
       
        myRigidbody = GetComponent<Rigidbody2D>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        // every frame we reset how much the player has changed
        change = Vector3.zero;
        // access input
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //if there is a change happening
        if(change != Vector3.zero)
        {
            MoveCharacter();
        }
        //Debug.Log(change);

    }
    void MoveCharacter()
    {
        //grabs the position of the player (+) the change (*) the speed (*) however much time has passed since the previous frame
        myRigidbody.MovePosition( transform.position + change * 
        speed * Time.deltaTime);

    }
}
