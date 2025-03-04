using UnityEngine;
using System.Collections;

public class offsetSlide : MonoBehaviour {
    
    Renderer laserMaterial;
    float offSetVar = 0;
    int frameVar = 0;
    void Start()
    {
        laserMaterial = this.GetComponent<Renderer>();
    }


    void Update()
    {
        
        offSetVar = offSetVar + 0.18f* Time.deltaTime;
        laserMaterial.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,offSetVar);
        
    }
}
