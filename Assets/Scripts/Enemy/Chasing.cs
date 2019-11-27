using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    Animator an;
    public bool isWalking;
    public Transform pointWalkRight;
    public Transform pointWalkLeft;
    public Transform pointAttack;

    public bool isWalkingToTheRight;
    public bool isWalkingToTheLeft;
    public bool readyToAttack;

    public float AttackRadius;
    public float WalkingRadius;
    public float enemySpeed;

    public LayerMask playerLayer;

    EnemyLife eL;
    public float attackTimer;
    public float attackTimerLimit;
    public Transform attackPoint;
    public GameObject attackPrefab;


    // Start is called before the first frame update
    void Start()
    {
      an = GetComponent<Animator>();
      eL = GetComponent<EnemyLife>();    
    }

    // Update is called once per frame
    void Update()
    {
      an.SetBool("Chasing", isWalking); 
      an.SetBool("Attacking", readyToAttack);

      isWalkingToTheRight = Physics2D.OverlapCircle(pointWalkRight.position, WalkingRadius, playerLayer);
      isWalkingToTheLeft = Physics2D.OverlapCircle(pointWalkLeft.position, WalkingRadius, playerLayer); 
      readyToAttack = Physics2D.OverlapCircle(pointAttack.position, AttackRadius, playerLayer); 


      if(readyToAttack && attackTimer < attackTimerLimit)
      {
        attackTimer += Time.deltaTime;
      }else
      {
        attackTimer = 0;
      }

      if(attackTimer >= attackTimerLimit)
      {
        Instantiate(attackPrefab, attackPoint.position, attackPoint.rotation);
      }



      if(isWalkingToTheLeft || isWalkingToTheRight)
      {
          isWalking = true;
      }else
      {
          isWalking = false;
      }

      if(isWalkingToTheRight)
      {
          gameObject.GetComponent<SpriteRenderer>().flipX = false;
          transform.position = Vector3.MoveTowards(transform.position, pointWalkRight.transform.position, enemySpeed * Time.deltaTime);
      }

      if(isWalkingToTheLeft)
      {
          gameObject.GetComponent<SpriteRenderer>().flipX = true;
          transform.position = Vector3.MoveTowards(transform.position, pointWalkLeft.transform.position, enemySpeed * Time.deltaTime);
      }

    }

    void OnDrawGizmosSelected()
    {
     Gizmos.color = Color.blue;
     Gizmos.DrawWireSphere(pointWalkRight.position, WalkingRadius);
     Gizmos.DrawWireSphere(pointWalkLeft.position, WalkingRadius);  
     Gizmos.DrawWireSphere(pointAttack.position, AttackRadius);  
    }

}
