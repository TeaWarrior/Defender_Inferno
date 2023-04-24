using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Transform graphyx;
    PlayerInput_Pc plInput;
    Vector3 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        plInput = GetComponent<PlayerInput_Pc>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotationGraphyx();
    }
    void RotationGraphyx()
    {
        
        rotationVector = plInput.GetMoveVector();
        if (rotationVector.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotationVector); // получаем кватернион поворота
            graphyx.rotation = targetRotation;
          
        }
    
    }
}
