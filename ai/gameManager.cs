using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    public AI muha;
    public AI kupec;
    public bool firstStep = false;
    public Animator black;

    public GameObject teleportHram;
    public GameObject teleportVillage;

    public string status;
    public GameObject[] faza2;

    public getAnything ga;
    public GameObject kupecGO;
    public GameObject muhaGO;

    public bool faze2Act = true;

    public GameObject pos1;
    public GameObject pos2;

    public GameObject[] osob;

    public Animator ending;
    public GameObject endingSound;
    // Start is called before the first frame update
    void Start()
    {
        endingSound.SetActive(false);
        faze2Act = true;
        for (int i = 0; i < faza2.Length; i++)
        {
            faza2[i].SetActive(false);
        }
        kupecGO.SetActive(false);


        for (int i = 0; i < osob.Length; i++)
        {
            osob[i].transform.position = pos2.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ga.playerGetMe)
        {
            muhaGO.SetActive(false);
            kupecGO.SetActive(true);
        }
        if (kupec.end && faze2Act)
        {
            faze2Act = false;
            ga.canipull = true;
            for (int i = 0; i < faza2.Length; i++)
            {
                faza2[i].SetActive(true);

            }
            for (int j = 0; j < osob.Length; j++)
            {
                osob[j].transform.position = pos1.transform.position;
            }
        }
        if (ga.endGo)
        {
            ending.SetTrigger("end");
            endingSound.SetActive(true);
            StartCoroutine(wait());
        }
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(13);
        SceneManager.LoadScene("menu");

    }

}
