using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : SimpleBullet
{
   
    public string playerTag="Player";

   
    
    // Start is called before the first frame update
    void Start()
    {
       
     
        Destroy(gameObject, 0.3f);

    }

 
    
 

    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.CompareTag(playerTag))
           
                if (other.gameObject.GetComponent<CharacterStats>() != null)
                {
                    other.gameObject.GetComponent<CharacterStats>().TakeDamage(bulletDamage);
                Debug.Log(bulletDamage);
                    Destroy(gameObject);

                }
            
        

    }

}
