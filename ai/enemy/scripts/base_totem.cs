using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_totem : MonoBehaviour
{
    public int hp = 100;
    public string name;
    public int stacks = 0;
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator deth()
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
}
