using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHpBar : MonoBehaviour
{

    public static PlayerHpBar Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerHpBar>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("PlayerHpBar");
                    instance = instanceContainer.AddComponent<PlayerHpBar>();
                }
            }

            return instance;
        }
    }

    private static PlayerHpBar instance;

    public int maxHp;
    public int currentHp;

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;


    //public Slider hpBar;
    //public Text playerHpText;

    // Start is called before the first frame update
    void Start()
    {
        hp1.GetComponent<Image>().enabled = true;
        hp2.GetComponent<Image>().enabled = true;
        hp3.GetComponent<Image>().enabled = true;
        hp4.GetComponent<Image>().enabled = true;

        hp5.GetComponent<Image>().enabled = true;

      
    }

    // Update is called once per frame
    void Update()
    {

        //hpBar.value = currentHp / maxHp;
        //playerHpText.text = "" + currentHp;

        switch (currentHp)
        {
            case 4:
                hp5.GetComponent<Image>().enabled = false;
                break;
            case 3:
                hp4.GetComponent<Image>().enabled = false;
                break;
            case 2:
                hp3.GetComponent<Image>().enabled = false;
                break;

            case 1:
                hp2.GetComponent<Image>().enabled = false;
                break;

            case 0:
                hp1.GetComponent<Image>().enabled = false;
                
                break;
        }
    }


    
}
