using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal : MonoBehaviour
{

    private int count;
    private Animator anim;
    private string currentState;

    //animation states
    const string Crystal_Idle = "Crystal_Idle";
    const string Crystal_1 = "Crystal_1";
    const string Crystal_2 = "Crystal_2";
    const string Crystal_3 = "Crystal_3";
    const string Crystal_4 = "Crystal_4";
    const string Crystal_5 = "Crystal_5";
    const string Crystal_6 = "Crystal_6";

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        count = 0;
       /* Animator[] states = new Animator[7];
        for(int i = 0; i < 7; i++)
        {
            states[i] = Animator.GetComponent<>  "CrystalBreak_" + i;
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        anim.Play(newState);

        //reassign the current state
        currentState = newState;
    }
    public void Crack()
    {
        print(count);
        if(count < 7)
        {
            count++;
            anim.SetInteger("crack", count);
        }  
        //count = anim.GetInteger("crack");
        //anim.SetInteger("crack", count++);
        print(count);
        //Debug.Log(count);
        
        
    }
   /* public void SetCrack(bool b)
    {
        anim.SetBool("crack", b);
    }*/
}
