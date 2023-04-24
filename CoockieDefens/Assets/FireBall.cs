using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : SimpleBullet
{

    public float speed;
    Vector3 direction;
    public override void SetDamage(int damage)
    {
        bulletDamage = 10 * damage;

        
    }

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LiveTIme());
    }
    IEnumerator LiveTIme()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<IDamagable>() != null)
        {
            other.gameObject.GetComponent<IDamagable>().TakeDamage(bulletDamage);
           
            Debug.Log("PlayerBullet");
            

        }
    }
}
