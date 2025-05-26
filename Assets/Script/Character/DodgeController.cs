using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodgeController : MonoBehaviour
{
    public static DodgeController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DodgeController>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("DodgeController");
                    instance = instanceContainer.AddComponent<DodgeController>();
                }
            }
            return instance;
        }
    }
    private static DodgeController instance;
    Animator anim;
    Rigidbody rigid;
    public bool isdodge = false;
    public float DodgeCool = 3;
    public float currentCool = 0;
    public int DodgeCount = 2;
    public Button button;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        button.onClick.AddListener(Dodge);
    }
    private void Update()
    {
        currentCool += Time.deltaTime;        
    }
    void Dodge()
    {       
        if (currentCool >= DodgeCool&&!isdodge)
        {
            PlayerMovement.Instance.moveSpeed = 40.0f;
            anim.SetTrigger("doDodge");
            isdodge = true;
            currentCool = 0;
            Invoke("DodgeOut", 0.4f);
        }
        else if(currentCool >= DodgeCool)
        {
            isdodge = false;
        }   
    }
    void DodgeOut()
    {
        PlayerMovement.Instance.moveSpeed = 5.0f;
        isdodge = false;
    }
}

