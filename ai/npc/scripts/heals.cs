using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heals : MonoBehaviour
{
    public base_totem bt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.GetComponent<player_stats>().hp);
            other.gameObject.GetComponent<player_stats>().hp = other.gameObject.GetComponent<player_stats>().maxHp;
            bt.stacks = 0;
            Destroy(transform.gameObject);
        }
    }
}
