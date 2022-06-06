
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PlayerMovement>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("PlayerMovement");
                    instance = instanceContainer.AddComponent<PlayerMovement>();
                }
            }
            return instance;
        }
    }

    private static PlayerMovement instance;

    Rigidbody rigid;
    public float moveSpeed = 5.0f;
    public Animator Anim;
    public GameObject gameoverpopup;
    public bool isDamage;
    
   
   
    public AudioClip audiohit;
    
    AudioSource audiosource1;
    
    public bool changecheck;
    

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();
        
        audiosource1 = GetComponent<AudioSource>();

        
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        if(JoyStickMovement.Instance.joyVec.x != 0 || JoyStickMovement.Instance.joyVec.y != 0)
        {
            rigid.rotation = Quaternion.LookRotation(new Vector3(JoyStickMovement.Instance.joyVec.x, 0, JoyStickMovement.Instance.joyVec.y));
            rigid.velocity = new Vector3(JoyStickMovement.Instance.joyVec.x, 0, JoyStickMovement.Instance.joyVec.y) * moveSpeed;
            
        }
        
        
        
        if (PlayerHpBar.Instance.currentHp == 0)
        {
            Anim.SetTrigger("doDie");
            
            gameoverpopup.SetActive(true);
            

        }
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.transform.CompareTag("NextRoom"))
        {
            Debug.Log("NextRoom");
            StageManager.Instance.NextStage();
        }
        */
        bool isBossAtk = other.name == "BossMeleeAtk";
        if (other.tag == "enemybolt")
        {
            
            if (!isDamage)
            {
                PlayerHpBar.Instance.currentHp -= Enemy.Instance.enemyboltDmg;
                
                StartCoroutine(OnDamage(isBossAtk));
            }
            Destroy(other.gameObject);
        }
        else if(other.tag == "MeleeAtk")
        {
            if (!isDamage)
            {
                PlayerHpBar.Instance.currentHp -= Enemy.Instance.enemyboltDmg;
                

                StartCoroutine(OnDamage(isBossAtk));
            }
        }

        IEnumerator OnDamage(bool isBossAtk)
        {
            isDamage = true;

            audiosource1.clip = audiohit;

            audiosource1.Play();
            Anim.SetTrigger("isHit");
            if (isBossAtk)
            {
                rigid.AddForce(transform.forward * -25, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(1f);

            isDamage = false;

            if (isBossAtk)
            {
                rigid.velocity = Vector3.zero;
            }
        }
        
    }

    
}
