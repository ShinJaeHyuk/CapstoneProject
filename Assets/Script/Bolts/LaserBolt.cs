using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBolt : MonoBehaviour
{
   
    public GameObject Laser; // 2???? ?????? ?? ?????? 

    LineRenderer lr;

    void Start()
    {
        lr = Laser.GetComponent<LineRenderer>();
        lr.enabled = false;
       
    }

    void Update()
    {
        if (lr.enabled)
        {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);

            if (hit.transform.CompareTag("Player"))
            {
               //PlayerHpBar.Instance.currentHp -= Time.deltaTime * 1;// LaserDMG;
                
            }
            
        }
    }
}
