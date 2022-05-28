using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBolt : MonoBehaviour
{

  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("JustDodge"))
        {
            Debug.Log("dodge");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("JustDodge"))
        {
            PlayerTargeting.Instance.ShootCount += 1;
            Debug.Log(PlayerTargeting.Instance.ShootCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
