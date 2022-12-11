using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : base_totem
{
    public GameObject boom;
    // Start is called before the first frame update
    void Start()
    {
        boom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            hp = 0;
            dead();
        }
    }
    public void dead()
    {
        boom.SetActive(true);
        Destroy(gameObject);
    }
}
