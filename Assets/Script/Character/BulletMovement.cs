using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    float bulletSpeed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Border"))
        {
            Destroy(this.gameObject);
        }
    }
}
