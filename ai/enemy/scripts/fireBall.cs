using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    public GameObject player;
    public fireTotem fireTotem;

    public float speed = 0.2f;


    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.Translate(new Vector3(0, 0, speed));
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            fireTotem.stacks += 1;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag != "totem")
        {
            Destroy(gameObject);
        }
    }
}
