using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int curHealth;
    public bool death;

    Animator an;

    public float timeToDestroy;

    BoxCollider2D box;
    
    // Start is called before the first frame update
    void Start()
    {
      an = GetComponent<Animator>();
      box = GetComponent<BoxCollider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
      if(curHealth <= 0)
      {
        death = true;
        box.enabled = false;
      }

      an.SetBool("Death", death);

      if(death)
      {
        Destroy(gameObject, timeToDestroy);
      }

    }

    public void Damage(int dmg)
    {
      curHealth -= dmg;
      gameObject.GetComponent<Animation>().Play("EnemyRedFlash");
    }
}
