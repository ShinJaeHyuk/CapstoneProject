using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int meleeDmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHpBar.Instance.currentHp -= meleeDmg;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
