using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenericTurn : MonoBehaviour
{
    [SerializeField]
    Vector3 TurnDirection;
    public float Speed;
    [SerializeField]
    bool DelayedStart = false;
    [SerializeField]
    float DelayTime;
    bool turning = false;
    [SerializeField] bool Lerping;
    void Start()
    {
        if (DelayedStart)
        {
             Invoke("StartTurning", DelayTime);
        }
        else
        {
            turning = true;
        }

    }
    private void OnEnable()
    {
        if (Lerping)
        {
            InvokeRepeating("RiseLerp", 0, 0.1f);
            Speed = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (turning)
        {
            
            transform.Rotate(TurnDirection * Speed * Time.fixedDeltaTime);
        }
        
    }

    void StartTurning()
    {
        turning = true;
    }

    void StopTurning()
    {
        turning = false;
    }
    void RiseLerp()
    {
        Speed += 4;
        if (Speed >= 100) CancelInvoke("RiseLerp");
    }
}
