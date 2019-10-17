using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPrefab : MonoBehaviour
{
    public float AttackPrefabLife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Destroy(gameObject, AttackPrefabLife);    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Enemy")
      {
        other.GetComponent<EnemyLife>().Damage(1);  
      }    
    }
}
