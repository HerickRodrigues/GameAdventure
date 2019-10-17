using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int curHealth;
    public bool death;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int dmg)
    {
      curHealth -= dmg;
      gameObject.GetComponent<Animation>().Play("EnemyRedFlash");
    }
}
