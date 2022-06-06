using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Enemy>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("Enemy");
                    instance = instanceContainer.AddComponent<Enemy>();
                }
            }
            return instance;
        }
    }

    private static Enemy instance;
    public Transform target;
    public enum Type { melee, assault, shoot, boss}; // melee - ????, assault - ????, shoot - ??????
    public Type enemyType;
    public int maxHealth;
    public int curHealth;
    public int enemyboltDmg;
    public bool isChase;
    public bool isAttack;
    public bool isDead;

    public GameObject EnemyBolt;

    public Transform GenPos;
    public BoxCollider meleeArea;
    public NavMeshAgent nav;
    public Animator anim;
    public Rigidbody rigid;
    public BoxCollider  boxCollider;
    public GameObject VictoryPopup;


    
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
                
        if(enemyType != Type.boss) {
            Invoke("ChaseStart", 2);
        }
        
    }
    
    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
    }

    

    // Update is called once per frame
    void Update()
    {
        if (nav.enabled && enemyType != Type.boss) {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }
    }
   

    void FixedUpdate()
    {
        Targeting();
        FreezeVelocity();
    }

    void Targeting()
    {
        if(!isDead && enemyType != Type.boss)
        {
            float targetRadius = 0;
            float targetRange = 0;

            switch (enemyType)
            {
                case Type.melee:
                    targetRadius = 1.5f;
                    targetRange = 3f;
                    break;

                case Type.assault:
                    targetRadius = 1f;
                    targetRange = 6f;
                    break;


                case Type.shoot:
                    targetRadius = 0.5f;
                    targetRange = 25f;
                    break;


            }

            RaycastHit[] rayHits = Physics.SphereCastAll(transform.position,
                targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));

            if (rayHits.Length > 0 && !isAttack)
            {
                StartCoroutine(Attack());
            }
        }
        
    }

    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("isAttack", true);

        switch (enemyType)
        {
            case Type.melee:
                
                yield return new WaitForSeconds(0.5f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(1f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(1f);
                break;

            case Type.assault:

                yield return new WaitForSeconds(0.1f);
                rigid.AddForce(transform.forward * 20, ForceMode.Impulse);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.5f);
                rigid.velocity = Vector3.zero;
                meleeArea.enabled = false;

                yield return new WaitForSeconds(2f);
                break;

            case Type.shoot:
                yield return new WaitForSeconds(0.5f);
                GameObject instantBullet = Instantiate(EnemyBolt, GenPos.position, transform.rotation);
                Rigidbody rigidbullet = instantBullet.GetComponent<Rigidbody>();
                rigidbullet.velocity = transform.forward * 20;

                yield return new WaitForSeconds(2f);
                
                break;
                          
        }
                
        isChase = true;
        isAttack = false;
        anim.SetBool("isAttack", false);

    }

   

    void FreezeVelocity()
    {
        if (isChase) {
            rigid.angularVelocity = Vector3.zero;
            rigid.velocity = Vector3.zero;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {            
            curHealth -= PlayerTargeting.Instance.bulletDamage;
            Vector3 reactVec = transform.position - other.transform.position;
            Destroy(other.gameObject);
            StartCoroutine(OnDamage(reactVec));
        }
                
    }
    
    IEnumerator OnDamage(Vector3 reactVec)
    {
       
        yield return new WaitForSeconds(0.1f);

        if (curHealth <= 0)
        {
            
            gameObject.layer = 15;
            isDead = true;
            isChase = false;
            nav.enabled = false;
            anim.SetTrigger("doDie");

            reactVec = reactVec.normalized;
            reactVec += Vector3.up;
            rigid.AddForce(reactVec * 5, ForceMode.Impulse);


            PlayerTargeting.Instance.MonsterList.Remove(transform.gameObject);
            RoomCondition.Instance.monCount -=1;

            Debug.Log(PlayerTargeting.Instance.MonsterList.Count);
            Debug.Log(RoomCondition.Instance.monCount);
            

            
            
            PlayerTargeting.Instance.TargetIndex = -1;
            if(enemyType != Type.boss)
            {
                Destroy(this.gameObject, 4);
            }
            else if(enemyType == Type.boss)
            {
                VictoryPopup.SetActive(true);
            }

        }

        
    }

  
}
