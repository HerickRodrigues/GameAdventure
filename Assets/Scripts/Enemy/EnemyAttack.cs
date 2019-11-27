using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float attackPrefabLife;

    private Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       Destroy(gameObject, attackPrefabLife);    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && other.isTrigger != true && playerTrans.transform.position.x > transform.position.x)
        {
            other.GetComponent<Player>().Damage(2);
            other.GetComponent<Player>().KnockbackRight();
            
        }

        else if(other.tag == "Player" && other.isTrigger != true && playerTrans.transform.position.x < transform.position.x)
        {
            other.GetComponent<Player>().Damage(2);
            other.GetComponent<Player>().KnockbackLeft();
            
        }     

    }

}
