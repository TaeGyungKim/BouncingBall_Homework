using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIsapperMe : MonoBehaviour
{
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rend.enabled = false;
    }
}