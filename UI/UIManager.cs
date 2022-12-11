using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Sprite thunder;
    public Sprite fire;
    public Sprite poision;

    public Sprite empty;


    public Image[] visualStacks;



    public thunder_totem tt;
    public poison_totem pt;
    public fireTotem ft;

    public Text[] textTot;


    public GameObject[] miniMapCourse;

    public base_totem[] bt;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < miniMapCourse.Length; i++)
        {
            miniMapCourse[i].SetActive(true);
        }
        for (int i = 0; i < visualStacks.Length; i++)
        {
            visualStacks[i].sprite = empty;

        }
    }

    // Update is called once per frame
    void Update()
    {
        full_image_stacks();
        bool off = false;
        for (int i = 0; i < bt.Length; i++)
        {
            if (bt[i].stacks >= 6)
            {
                    off = true;  
            }

        }
            for (int i = 0; i < bt.Length; i++)
            {
                miniMapCourse[i].SetActive(!off);
            }
        

    }

    public void full_image_stacks()
    {
        int j = 0;
        for (int i = 0; i < bt.Length; i++)
        {
            if (bt[i].stacks != 0)
            {
                if (bt[i].name == "fire")
                {
                    visualStacks[j].sprite = fire;
                }
                else if (bt[i].name == "thunder")
                {
                    visualStacks[j].sprite = thunder;
                }
                else if (bt[i].name == "posion")
                {
                    visualStacks[j].sprite = poision;
                }
                textTot[j].text = bt[i].stacks.ToString();
                j++;
            }
        }
        for (int i = j; i < visualStacks.Length; i++)
        {
            visualStacks[j].sprite = empty;
            textTot[j].text = "";
        }


    }
    public bool check(int i)
    {
        bool yeap = true;
        for (int j = 0; j < visualStacks.Length; j++)
        {
            if (visualStacks[i] == visualStacks[j] && visualStacks[j] != empty)
            {
                yeap = false;
            }

        }

        return yeap;
    }
}
