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


    /*
     public float DodgeCool = 3;
     public float currentCool = 0;
     public bool isDodge = false;
     public float dodgeDistance = 0.5f;

     Vector3 direction;

     public Button btn;

     // Start is called before the first frame update
     void Start()
     {
         btn.onClick.AddListener(Dodge);
         direction = PlayerTargeting.Instance.dir;
     }

     // Update is called once per frame
     void Update()
     {
         currentCool += Time.deltaTime;
         if (Input.GetKey(KeyCode.Space) && isDodge == false && currentCool >= DodgeCool)
         {
             Debug.Log("dodge");
             isDodge = true;
             currentCool = 0;
             Dodge();
             transform.Translate(Vector3.forward);
         }
         else if(currentCool >= DodgeCool)
         {
             isDodge = false;
         }
     }

     void Dodge()
     {
         RaycastHit hit;
         if(Physics.Raycast(transform.position, direction, out hit, dodgeDistance))
         {
             GameObject hitTarget = hit.collider.gameObject;

             transform.position = hit.point;
         }

         else
         {
             GetComponent<Rigidbody>().AddForce(transform.forward * dodgeDistance, ForceMode.Impulse);
         }
     }

    */

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        button.onClick.AddListener(Dodge);

    }

    private void Update()
    {
        currentCool += Time.deltaTime;
        if (currentCool>=DodgeCool && !isdodge && Input.GetKey(KeyCode.Space))  //?????? ???????? ???? space?? ????????. ???? ???????? ?????? ???? ???? ??
        {
            isdodge = true;
            currentCool = 0;
            Dodge();
        }

        else if(currentCool >= DodgeCool)
        {
            isdodge = false;
        }
        
    }


   
    void Dodge()
    {
        
        PlayerMovement.Instance.moveSpeed = 40.0f;
        anim.SetTrigger("doDodge");
        isdodge = true;

        Invoke("DodgeOut", 0.4f);
        
    }
    

    void DodgeOut()
    {
        PlayerMovement.Instance.moveSpeed = 5.0f;
        isdodge = false;
    }

   
    
}

