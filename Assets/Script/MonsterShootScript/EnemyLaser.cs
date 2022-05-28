using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser: MonoBehaviour
{
    RoomCondition RoomConditionGO;
    GameObject Player;

    public Transform BoltGenPosition;
    public bool lookAtPlayer = true;
    public GameObject LaserEffect;

    float attackTime = 5f;
    float attackTimeCalc = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        RoomConditionGO = transform.parent.transform.parent.gameObject.GetComponent<RoomCondition>();
        LaserEffect.SetActive(false);
        StartCoroutine(WaitPlayer());
        StartCoroutine(LaserOff());
    }

    IEnumerator LaserOff()
    {
        while (true)
        {
            yield return null;
            if (LaserEffect.activeInHierarchy)
            {
                attackTimeCalc -= Time.deltaTime;
                if (attackTimeCalc <= 0)
                {
                    attackTimeCalc = attackTime;
                    LaserEffect.SetActive(false);
                }
            }
        }
    }

    IEnumerator WaitPlayer()
    {
        yield return null;

        while (!RoomConditionGO.playerInThisRoom)
        {
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(6f);
        StartCoroutine(SetTarget());

        yield return new WaitForSeconds(1.5f);
        Shoot();

        StartCoroutine(Targeting());
    }

    IEnumerator SetTarget()
    {
        LaserEffect.SetActive(true);

        while (true)
        {
            yield return null;
            if (!lookAtPlayer) break; // 이 위치 Line 지워짐
                                      

            transform.LookAt(Player.transform.position);
        }
    }

    IEnumerator Targeting()
    {
        while (true)
        {
            yield return null;
            if (!LaserEffect.activeInHierarchy)
            {
                break;
            }
            Quaternion targetRotation = Quaternion.LookRotation(Player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        }
    }

    public void Shoot()
    {
        lookAtPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
