using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunder_totem : base_totem
{
    public thunder_totem myThunderTotem;
    public movePlayer movePlayer;
    public float walk = 0f;
    public float run = 0f;

    public float cdLighting = 2f;
    public GameObject light;
    public GameObject spawnPoint;
    public float delayspawnAnddd = 3f;

    public Transform playerPos;
    public float step_size_cd = 0.1f;

    public GameObject thunderEffect;
    public float timer;
    public float timer_off;

    public float speedDebuf = 0.05f;
    public bool playerHere = false;
    // Start is called before the first frame update
    
    void Start()
    {
        walk = movePlayer._moveSpeed;
        run = movePlayer._runSpeed;
        Stacks();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            stacks = 0;
            movePlayer._moveSpeed = walk;
            movePlayer._runSpeed = run;
            thunderEffect.SetActive(false);
            stacks = 0;
            movePlayer._moveSpeed = walk;
            movePlayer._runSpeed = run;
            deathEffect.SetActive(true);
            StartCoroutine(deth());
            
        }
    }
    public void Stacks()
    {
        
            StartCoroutine(stackObr());
        
    }

    public void lightinfF()
    {
        if (playerHere)
        {
            StartCoroutine(lightintZh());
        }
        else
        {
            StartCoroutine(waitPlayer());
        }
    }

    public IEnumerator waitPlayer()
    {
        yield return new WaitForSeconds(2);
        lightinfF();
    }
    

        public IEnumerator lightintZh()
    {
        yield return new WaitForSeconds(cdLighting);

        float t = 0;

        GameObject spawnedLighting = Instantiate(light, spawnPoint.transform.position, Quaternion.identity);
        
        while (t < 1)
        {
            spawnedLighting.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(5, 5, 5), t);
            t += 0.01f;
            yield return new WaitForSeconds(step_size_cd);
        }
        spawnedLighting.GetComponent<thunderBall>().player = new Vector3(playerPos.position.x, playerPos.position.y, playerPos.position.z);
        spawnedLighting.GetComponent<thunderBall>().tt = myThunderTotem;

        yield return new WaitForSeconds(delayspawnAnddd);
        spawnedLighting.GetComponent<thunderBall>().go = true;

    }

    public IEnumerator stackObr()
    {
        if (stacks > 0)
        {
            thunderEffect.SetActive(true);
        }
        if (playerHere)
        {
            lightinfF();
            timer = Time.time;
        }
        else if (timer + timer_off <= Time.time)
        {
            stacks = 0;
            movePlayer._moveSpeed = walk;
            movePlayer._runSpeed = run;
            thunderEffect.SetActive(false);
            
        }

        movePlayer._moveSpeed = walk;
        movePlayer._runSpeed = run;
        Debug.Log((float)stacks * (float)speedDebuf);
        movePlayer._moveSpeed -= (float)stacks * (float)speedDebuf;
        movePlayer._runSpeed -= (float)stacks * (float)speedDebuf;

        Debug.Log(movePlayer._runSpeed);
        
        yield return new WaitForSeconds(2f);
        Stacks();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHere = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = false;
        }
    }
}
