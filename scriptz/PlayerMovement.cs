using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    walk,
    shoot,
    interact,
    drill,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public GameObject projectile;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    


    // Start is called before the first frame update
    void Start()
    {
        
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // every frame we reset how much the player has changed
        change = Vector3.zero;
        // access input
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        // UpdateAnimationdAndMove();
        if(Input.GetButtonDown("shoot") && currentState != PlayerState.shoot && currentState != PlayerState.stagger)
        {
            StartCoroutine(ShootCo());
        }
        else if(Input.GetButtonDown("drill") && currentState != PlayerState.drill && currentState != PlayerState.stagger)
        {
            StartCoroutine(DrillCo());
        }
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationdAndMove();
        }
        //Debug.Log(change);
      
    }
    void ChangeAnimationState(string newState)
    {

    }
    private IEnumerator DrillCo()
    {
        animator.SetBool("drilling", true);
        currentState = PlayerState.drill;
        yield return null;
        animator.SetBool("drilling", false);
        yield return new WaitForSeconds(.25f);
        currentState = PlayerState.walk;
    }
    private IEnumerator ShootCo()
    {
        animator.SetBool("shooting", true);
        currentState = PlayerState.shoot;
        yield return null;
        MakeBullet();
        yield return new WaitForSeconds(.3f);
        animator.SetBool("shooting", false);
        currentState = PlayerState.walk;

    }
    private void MakeBullet()
    {
        Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Bullet bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Setup(temp, ChooseBulletDirection());
    }
    Vector3 ChooseBulletDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0,0,temp);
    }
    void UpdateAnimationdAndMove()
    {
        //if there is a change happening
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        //grabs the position of the player (+) the change (*) the speed (*) however much time has passed since the previous frame
        myRigidbody.MovePosition( transform.position + change * 
        speed * Time.deltaTime);

    }
    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private IEnumerator KnockCo(float knockTime)
    {

        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;

        }
    }
}
