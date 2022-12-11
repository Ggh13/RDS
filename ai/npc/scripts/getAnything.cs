using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAnything : MonoBehaviour
{
    public bool playerHere = false;
    public bool playerGetMe = false;
    public GameObject skin;
    public GameObject pressE; // Start is called before the first frame update
    public bool canipull = false;
    public bool endGo = false;
    void Start()
    {
        canipull = false;
        endGo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHere && Input.GetKeyUp(KeyCode.E) && !playerGetMe) {
            //pressE.SetActive(false);
            skin.SetActive(false);
            playerGetMe = true;
        }
        if (playerHere && Input.GetKeyUp(KeyCode.E) && canipull)
        {
            skin.SetActive(true);
            StartCoroutine(endingKor());
             

        }

    }
    public IEnumerator endingKor()
    {
        
        yield return new WaitForSeconds(3);
        endGo = true;

    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pressE.SetActive(true);
            playerHere = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressE.SetActive(false);
            playerHere = false;
        }
    }
}
