
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTargeting : MonoBehaviour
{
    public static PlayerTargeting Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PlayerTargeting>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("PlayerTargeting");
                    instance = instanceContainer.AddComponent<PlayerTargeting>();
                }
            }
            return instance;
        }
    }

    private static PlayerTargeting instance;

    Animator anim;
    public bool getATarget = false;
    float currentDist = 0; //current distance
    float closetDist = 100f; //closest distance
    float TargetDist = 100f; //distance to target
    int closeDistIndex = 0; //closest index
    public int TargetIndex = -1; //index to target
    int prevTargetIndex = 0;
    public LayerMask layerMask;
    
    public AudioClip audioshot;
    public AudioClip audioblank;
    AudioSource audioSource2;
    AudioSource audioSource3;
    
    public int ShootCount = 10;

    public float atkSpd = 1f;

    public int bulletDamage = 10;

    public float bulletSpeed = 1.5f;
    //const float shootDelay = 0.3f;
    //float shootTimer = 0;
    public Vector3 dir; //?????? ???????? ????

    
    public GameObject[] grenades;
    public int hasGrenade;
    public GameObject grenadeObj;
    
    public bool grenadedown;
    

    public Button btn;

    public List<GameObject> MonsterList = new List<GameObject>(); //monster list
    public GameObject PlayerBolt;
    public Transform AttackPoint;

    void OnDrawGizmos()
    {
        if (getATarget)
        {
            for(int i = 0; i < MonsterList.Count; i++)
            {
                if(MonsterList[i] == null) { return; }
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, MonsterList[i].transform.position - transform.position, out hit, 20f, layerMask);

                if(isHit && hit.transform.CompareTag("Monster"))
                {
                    Gizmos.color = Color.green;
                }
                else
                {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawRay(transform.position, MonsterList[i].transform.position - transform.position);
            }
        }
    }

    void Start()
    {
        btn.onClick.AddListener(shoot);
        dir = new Vector3(AttackPoint.position.x, 0, AttackPoint.position.z - transform.position.z).normalized;
                
        anim = GetComponentInChildren<Animator>();
        
        audioSource2 = GetComponent<AudioSource>();
        audioSource3 = GetComponent<AudioSource>();
        
        
    }
    // Start is called before the first frame update
    void Update()
    {
        SetTarget();
        Grenade();
        

    }

    void Grenade()
    {
        if (hasGrenade == 0)
        {
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GameObject instantGrenade = Instantiate(grenadeObj, AttackPoint.position, transform.rotation);
            Rigidbody rigidGrenade = instantGrenade.GetComponent<Rigidbody>();
            rigidGrenade.AddForce(transform.forward, ForceMode.Impulse);
            rigidGrenade.AddTorque(Vector3.back * 2, ForceMode.Impulse);

            hasGrenade--;
            grenades[hasGrenade].SetActive(false);
        }
    }

    // Update is called once per frame
    
    
    void SetTarget()
    {
        if (MonsterList.Count != 0)
        {
            prevTargetIndex = TargetIndex;
            currentDist = 0f;
            closeDistIndex = 0;
            TargetIndex = -1;

            for (int i = 0; i < MonsterList.Count; i++)
            {
                if(MonsterList[i] == null) { return; }
                currentDist = Vector3.Distance(transform.position, MonsterList[i].transform.position);

                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, MonsterList[i].transform.position - transform.position, out hit, 20f, layerMask);

                if (isHit && hit.transform.CompareTag("Monster"))
                {
                    if (TargetDist >= currentDist)
                    {
                        TargetIndex = i;
                        TargetDist = currentDist;
                        if(!JoyStickMovement.Instance.isPlayerMoving && prevTargetIndex != TargetIndex)
                        {
                            TargetIndex = prevTargetIndex;
                        }
                    }
                }

                if (closetDist >= currentDist)
                {
                    closeDistIndex = i;
                    closetDist = currentDist;
                }
            }

            if (TargetIndex == -1)
            {
                TargetIndex = closeDistIndex;
            }

            closetDist = 100f;
            TargetDist = 100f;
            getATarget = true;
        }
    }

 
    void shoot()
    {
        
        if (ShootCount != 0) {
            //dir = new Vector3(AttackPoint.position.x, 0, AttackPoint.position.z - transform.position.z).normalized;
            anim.SetTrigger("doAttack");
            audioSource2.clip = audioshot;
            

            audioSource2.Play();
            Instantiate(PlayerBolt, AttackPoint.position, AttackPoint.rotation);
            ShootCount--;
            Debug.Log(ShootCount);
        }
        else if(ShootCount == 0)
        {
            audioSource3.clip = audioblank;
            audioSource3.Play();
        }

    }
           
}
