using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private Rigidbody2D rb;
  private Transform tr;
  private Animator an;

  public bool isWalking;
  public bool facingRight;
  
  private float axis;
  public float vel;

  public float jumpForce;
  public Transform GroundCheck;
  public bool onTheGround;
  public float onTheGroundRadius;

  public LayerMask solid;

  public int curHealth;
  public int maxHealth;

  public bool death;

  public float knockback;
  public float knockbackCount;
  public float knockbackLength;

  public bool knockbackConfirm;


    // Start is calle before the first frame update
  void Start (){
    rb = GetComponent<Rigidbody2D>();
    tr = GetComponent<Transform>();
    an = GetComponent<Animator>();
    facingRight = true;

    curHealth = maxHealth;
    
    }

    // Update is called once per frame
  void Update()
  {
    
    onTheGround = Physics2D.OverlapCircle(GroundCheck.position, onTheGroundRadius, solid);

    axis = Input.GetAxisRaw("Horizontal");
    isWalking = Mathf.Abs(axis) > 0f;

    if(axis > 0f && !facingRight)
    {
      Flip();
    }else if(axis < 0f && facingRight)
    {
      Flip();     
    }
    
    Animations();

    if (Input.GetButtonDown("Jump") && onTheGround && !death)
    {
      rb.AddForce(tr.up * jumpForce);
    }

    if(curHealth > maxHealth)
    {
      curHealth = maxHealth;
    }

    if(curHealth <= 0)
    {
      death = true;
    }

    if(knockbackConfirm)
    {
      knockbackCount -= Time.deltaTime;
    }
    
    if(knockbackCount <= 0)
    {
      knockbackConfirm = false;
    }

  }

  void FixedUpdate()
  {
    if(!death && !knockbackConfirm)
    {
      if(isWalking && facingRight)
      {
        rb.velocity = new Vector2(vel, rb.velocity.y);      
      }else if(isWalking && !facingRight)
      {
        rb.velocity = new Vector2(-vel, rb.velocity.y);
      }
    }   
   }

  void Flip()
  {
    if(!death)
    {
      facingRight = !facingRight;
      tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
    }  
  }

  void Animations()
  {
    an.SetBool("Walking", isWalking);
    an.SetFloat("VerticalVel", rb.velocity.y);
    an.SetBool("Jumping", !onTheGround);
    an.SetBool("Death", death);
    an.SetBool("Knockback",knockbackConfirm);
  }

  void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(GroundCheck.position, onTheGroundRadius);
      
  }

  public void Damage(int dmg)
  {
    curHealth -= dmg;
    gameObject.GetComponent<Animation>().Play("PlayerDamageFlash");
  }

  public void KnockbackRight()
  {
    if(death == false)
    {
      rb.velocity = new Vector2(knockback, knockback*0);
      knockbackCount = knockbackLength;
      knockbackConfirm = true;
    }
  }

  public void KnockbackLeft()
  {
    if(death == false)
    {
      rb.velocity = new Vector2(-knockback, knockback*0);
      knockbackCount = knockbackLength;
      knockbackConfirm = true;
    }
  }

}

