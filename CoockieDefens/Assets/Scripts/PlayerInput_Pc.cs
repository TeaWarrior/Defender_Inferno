using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_Pc : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int maxSpeed;
    Rigidbody rb;
    Vector3 moveXY;
    // Start is called before the first frame update
    void Start()
    {
        rb=transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical")!=0)
        {
            moveXY = new Vector3(Input.GetAxisRaw("Horizontal"),0f, Input.GetAxisRaw("Vertical"));
            Move();
        }
    }
    private void Move()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveXY * speed);
           
        }
     
    }

    public Vector3 GetMoveVector()
    {
        return rb.velocity;
    }
}
