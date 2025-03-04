using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBlink : MonoBehaviour
{
    [SerializeField] float AlphaToValue;
    [SerializeField] float TimeValue;
    void Start()
    {
        iTween.FadeTo(this.gameObject, iTween.Hash("alpha", AlphaToValue, "time", TimeValue, "looptype", "pingpong"));
    }

    // Update is called once per frameunity 
    void Update()
    {
        
    }
}
