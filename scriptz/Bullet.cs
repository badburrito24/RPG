using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject player;
    public float speed;
    public Rigidbody2D myRigidbody;
    
    
  
   
    // Start is called before the first frame update
    void Start()
    {
       // myRigidbody = GetComponent<Rigidbody2D>();
       // Invoke("DestroySelf", 1f);

    }
    
    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }
   
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
