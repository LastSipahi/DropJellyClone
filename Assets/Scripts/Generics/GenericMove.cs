using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMove : MonoBehaviour
{
    [SerializeField]
    Vector3 Direction;
    [SerializeField]
    float Speed;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(Direction * Speed * Time.fixedDeltaTime);
    }
}
