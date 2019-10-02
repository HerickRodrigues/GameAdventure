using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour{
    private Transform playerTransf;
    // Start is called before the first frame update
    void Start()
    {
        playerTransf = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && other.isTrigger != true && playerTransf.transform.position.x > transform.position.x)
        {
            other.GetComponent<Player>().Damage(1);
            other.GetComponent<Player>().KnockbackRight();
        }
        else if(other.tag == "Player" && other.isTrigger != true && playerTransf.transform.position.x < transform.position.x)
        {
            other.GetComponent<Player>().Damage(1);
            other.GetComponent<Player>().KnockbackLeft();
        }

    }
}
