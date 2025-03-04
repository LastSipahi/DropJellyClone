using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTurnPingPong : MonoBehaviour
{
    [SerializeField]
    float TurnAngle;
    public float Time;
    [SerializeField]
    bool DelayedStart = false;
    [SerializeField]
    float DelayTime;

    void Start()
    {
        if (DelayedStart)
        {
            Invoke("StartPingPong", DelayTime);
        }
        else
        {
            StartPingPong();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPingPong()
    {
        iTween.RotateAdd(this.gameObject, iTween.Hash("z",TurnAngle,"time", Time, "looptype", "pingPong", "easetype", "linear"));

    }
}
