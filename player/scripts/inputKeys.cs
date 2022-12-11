using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputKeys : MonoBehaviour
{
    public float translation;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }
}
