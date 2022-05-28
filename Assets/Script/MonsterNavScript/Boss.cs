using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : Enemy
{

    Rigidbody rigid;
    public GameObject FireBall;
    public Transform FireballPort;

    Vector3 lookVec; //플레이어 방향 예측
    Vector3 tauntVec;
    public bool isLook;

    // Start is called before the first frame update
    void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        nav.isStopped = true;
        StartCoroutine(Think());
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            StopAllCoroutines();
            return;
        }
        if (isLook)
        {
            lookVec = new Vector3(1, 0, 1) * 5f;
            transform.LookAt(target.position + lookVec);

        }
        else
        {
            nav.SetDestination(tauntVec);
        }
    }
    IEnumerator Think()
    {
        yield return new WaitForSeconds(0.1f); // 얘 시간을 바꾸면 보스 난이도 바뀜

        int ranAction = Random.Range(0, 4);
        switch (ranAction)
        {
            case 0:
            case 1:

                StartCoroutine(FireballShot());
                break;
                //파이어볼
            case 2:               
            case 3:

                StartCoroutine(Taunt());
                break;
                //점프
            
        }              
    }

    IEnumerator FireballShot()
    {
        anim.SetTrigger("doShot");
        yield return new WaitForSeconds(0.3f);

        GameObject instantFireBall = Instantiate(FireBall, FireballPort.position, FireballPort.rotation);
        

        StartCoroutine(Think());
    }
    IEnumerator Taunt()
    {
        tauntVec = target.position + lookVec;

        isLook = false;
        nav.isStopped = false;
        boxCollider.enabled = false;
        anim.SetTrigger("doTaunt");

        yield return new WaitForSeconds(1.5f);

        meleeArea.enabled = true;

        yield return new WaitForSeconds(0.5f);

        meleeArea.enabled = false;

        yield return new WaitForSeconds(1f);
        isLook = true;
        nav.isStopped = true;
        boxCollider.enabled = true;
        StartCoroutine(Think());
    }       
}
