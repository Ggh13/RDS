using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderBall : MonoBehaviour
{
    public bool go = false;

    public Vector3 player;
    public float speed = 0.2f;
    public thunder_totem tt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.LookAt(player);
            transform.Translate(new Vector3(0, 0, speed));
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            tt.stacks += 1;
            Destroy(gameObject);
        }
    }
}
