using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject pressEGO;

    public int num_dialog = 0;
    public string[] dialog;
    public bool[] turn_talk;

    public GameObject dialog_go;
    public Text dialogText;
    public GameObject npcPic;
    public GameObject playerPic;

    public bool playerHere;

    public bool end = false;

    public Sprite me;
    public Image me_pic;

    public GameObject[] mySounds;
    // Start is called before the first frame update
    void Start()
    {
        num_dialog = 0;
        playerHere = false;
        pressEGO.SetActive(false);
        offAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHere)
        {
            pressE_F();
        }
        else
        {
            npcPic.SetActive(false);
            playerPic.SetActive(false);
            dialog_go.SetActive(false);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHere = true;
            me_pic.sprite = me;
            pressEGO.SetActive(true);

                offAll();
                mySounds[num_dialog].SetActive(true);
            
            

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = false;
            pressEGO.SetActive(false);

        }
    }
    public void pressE_F()
    {
        if (playerHere)
        {
            dialog_go.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                me_pic.sprite = me;
                num_dialog++;
                offAll();
                mySounds[num_dialog].SetActive(true);
            }
            if (num_dialog >= dialog.Length)
            {
                num_dialog--;
                end = true;
            }
            dialogText.text = dialog[num_dialog];
            npcPic.SetActive(turn_talk[num_dialog]);
            playerPic.SetActive(!turn_talk[num_dialog]);
            
        }
        else
        {
            dialog_go.SetActive(false);
        }
        
    }
    public void offAll()
    {
        for (int i = 0; i < mySounds.Length; i++)
        {
            mySounds[i].SetActive(false);
        }
    }
}
