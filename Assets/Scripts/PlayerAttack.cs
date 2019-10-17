using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackSpawner;
    public GameObject AttackPrefab;
    public bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.4f;

    private Animator an;

    // Start is called before the first frame update
    void Start()
    {
      an = gameObject.GetComponent<Animator>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(Input.GetKeyDown("f") && !attacking)
      {
        attacking = true;
        attackTimer = attackCd;

        Instantiate(AttackPrefab, attackSpawner.position, attackSpawner.rotation);    
      }

      if(attacking)
      {
        if(attackTimer > 0)
        {
          attackTimer -= Time.deltaTime;  
        }else
         {
           attacking = false;    
         }   
      }
      an.SetBool("Attacking", attacking);
    }
}
