using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour

{

    public string tag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    // if(GameObject.ReferenceEquals(firstGameObject, secondGameObject))
       // {
      // Debug.Log("first and second are the same");
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("breakable"))
        {
            if (tag == "drill") 
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
