using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison_totem : base_totem
{
    public bool have_player = false;
    public float cool_down_stack = 0;
    public player_stats player;
    public int dmgForStack = 1;
    public GameObject effect_poision;

    public float timer_off = 8f;
    public float timer = 8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(plusStack()); 
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            stacks = 0;
            effect_poision.SetActive(false);
            stacks = 0;
            deathEffect.SetActive(true);
            StartCoroutine(deth());
        }
    }
    void give_stack()
    {

        StartCoroutine(plusStack());

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            have_player = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            have_player = false;
        }
    }
    public IEnumerator plusStack()
    {

        yield return new WaitForSeconds(cool_down_stack);
        if (stacks > 0) { 
           effect_poision.SetActive(false);
           effect_poision.SetActive(true);
        }

        if (have_player)
        {
            stacks += 1;
            timer = Time.time;
        }

        else if (timer + timer_off <= Time.time)
        {
            stacks = 0;
            effect_poision.SetActive(false);
        }

        
        
        player.hp -= stacks * dmgForStack;
        give_stack();
        yield return null;
    }
}
