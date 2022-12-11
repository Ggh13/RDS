using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireTotem : base_totem
{

    public bool have_player = false;
    public float cool_down_stack = 0;
    public player_stats player_stats;
    public GameObject player;
    public int dmgForStack = 1;
    public GameObject effect_fire;

    public float timer_off = 8f;
    public float timer = 8f;

    public GameObject fireball;
    public GameObject spawnPoint;


    public GameObject deadEffect;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(plusStack());
        effect_fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            stacks = 0;
            effect_fire.SetActive(false);
            stacks = 0;
            deathEffect.SetActive(true);
            StartCoroutine(deth());
        }
    }
    void give_stack()
    {
        if (hp > 0)
        {
            StartCoroutine(plusStack());
        }
        

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
    public IEnumerator deadE()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
        yield return null;
    }
    public IEnumerator plusStack()
    {

        yield return new WaitForSeconds(cool_down_stack);
        if (stacks > 0)
        {
            effect_fire.SetActive(true);
        }


        if (!have_player)
        {
            if(timer + timer_off <= Time.time)
            {
                stacks = 0;
                effect_fire.SetActive(false);
            }
            
        }
        else
        {
            timer = Time.time;
        }
       
        if (have_player)
        {
           fireBall fb = Instantiate(fireball, spawnPoint.transform.position, Quaternion.identity).GetComponent<fireBall>();
            fb.fireTotem = transform.GetComponent<fireTotem>();
            fb.player = player;
        }

        player_stats.hp -= stacks * dmgForStack;
        give_stack();
        yield return null;
    }
}
