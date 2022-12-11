using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_totem : MonoBehaviour
{
    public base_totem bt;
    public SphereCollider poision_rad;
    public float cd_teleport = 5f;
    public GameObject skin;
    public float step_size = 0.01f;
    public float step_size_cd = 0.1f;

    public GameObject health;
    public GameObject spawnedHealth;
    public float cdSpawnHealth = 5f;

    public GameObject[] spawnedHelthes;
    public int nomHelth = 0;
    public GameObject sounds;
    // Start is called before the first frame update
    void Start()
    {
        sounds.SetActive(false);
        bt = transform.GetComponent<base_totem>();
        spawnedHelthes = new GameObject[5];
        spawnHp();
        teleport();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void teleport()
    {
        StartCoroutine(tp());
    }

    public void spawnHp()
    {
        if (bt.stacks > 0)
        {
            StartCoroutine(hp_spawn());
        }
        else
        {
            StartCoroutine(wait());
        }
        
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        spawnHp();
    }
        public IEnumerator hp_spawn()
    {
        yield return new WaitForSeconds(cdSpawnHealth);

        Vector2 rad_rand = Random.insideUnitCircle;
        spawnedHelthes[nomHelth] = Instantiate(health, new Vector3( transform.position.x + rad_rand.x * poision_rad.radius, transform.position.y + rad_rand.y * poision_rad.radius, transform.position.z + rad_rand.y * poision_rad.radius), Quaternion.identity);
        spawnedHelthes[nomHelth].GetComponent<heals>().bt = bt;
        spawnHp();
        nomHelth += 1;
        if (nomHelth >= spawnedHelthes.Length)
        {
            nomHelth = 0;
            Destroy(spawnedHelthes[nomHelth]);
        }
        yield return null;
    }


    public IEnumerator tp()
    {
        
        yield return new WaitForSeconds(cd_teleport);
        Vector3 start_size = new Vector3(skin.transform.localScale.x, skin.transform.localScale.y, skin.transform.localScale.z);
        float t = 0;
        Vector2 rad_rand = Random.insideUnitCircle;
        while (t < 1)
        {
            skin.transform.localScale = Vector3.Lerp(skin.transform.localScale, start_size / 50, t);
            t += 0.01f;
            yield return new WaitForSeconds(step_size_cd);
        }
        //Destroy(spawnedHealth);

        skin.transform.position = new Vector3(transform.position.x + rad_rand.x * poision_rad.radius, transform.position.y, transform.position.z + rad_rand.y * poision_rad.radius);
        
        t = 0;
        while (t < 1)
        {
            skin.transform.localScale = Vector3.Lerp(skin.transform.localScale, start_size, t);
            t += 0.01f;
            yield return new WaitForSeconds(step_size_cd);
        }
        teleport();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sounds.SetActive(true);
        }
    }
}
