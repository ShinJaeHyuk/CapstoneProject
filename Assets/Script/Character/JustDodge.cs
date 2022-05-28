using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JustDodge : MonoBehaviour
{
    public static JustDodge Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<JustDodge>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("JustDodge");
                    instance = instanceContainer.AddComponent<JustDodge>();
                }
            }
            return instance;
        }
    }

    private static JustDodge instance;

    public GameObject player;
    public float z = -9f;
    public float y = 1.5f;
    
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0,2,-9 );
        position.y = player.transform.position.y + y;
        position.x = player.transform.position.x;
        position.z = player.transform.position.z;

        transform.position = position;
    }
}
