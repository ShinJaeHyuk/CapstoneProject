using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBolt : MonoBehaviour
{
    Rigidbody rb;
    Vector3 NewDir;
    int bounceCnt = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        NewDir = transform.up;
        rb.velocity = NewDir * -10f;
    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("JustDodge")) {
            PlayerTargeting.Instance.ShootCount += 1;
            Debug.Log(PlayerTargeting.Instance.ShootCount);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.CompareTag("Border"))
        {
            bounceCnt--;
            if (bounceCnt > 0)
            {
                NewDir = Vector3.Reflect(NewDir, collision.contacts[0].normal);
                rb.velocity = NewDir * -10f;

            }
            else
            {
                Destroy(gameObject, 0.1f);
            }
        }
        
    }


   

    // Update is called once per frame
    void Update()
    {
        
    }
}
