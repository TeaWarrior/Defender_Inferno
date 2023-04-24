using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    
    public virtual void SetDamage(int damage)
    {
        bulletDamage = damage;
        
    }
    public int bulletDamage;

    bool isHited;

    // Start is called before the first frame update
    void Start()
    {


        Destroy(gameObject, 0.3f);

    }





    private void OnTriggerStay(Collider other)
    {


        if (!isHited)
        {
            if (other.gameObject.GetComponent<IDamagable>() != null)
            {
                other.gameObject.GetComponent<IDamagable>().TakeDamage(bulletDamage);
                isHited = true;
                Debug.Log("PlayerBullet");
                Destroy(gameObject);

            }
        }
       
        

    }
}


