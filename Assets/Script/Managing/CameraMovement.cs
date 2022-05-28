using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{

    public static CameraMovement Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<CameraMovement>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("CameraMovement");
                    instance = instanceContainer.AddComponent<CameraMovement>();
                }
            }
            return instance;
        }
    }

    private static CameraMovement instance;

    public GameObject Player;
    public float offsetY = 8f;
    public float offsetZ = -2f;

    Vector3 cameraPosition;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = Player.transform.position+ new Vector3(0, 4, -12);
        /*
        cameraPosition.y = Player.transform.position.y + offsetY;
        cameraPosition.z = Player.transform.position.z + offsetZ;

        transform.position = cameraPosition;
        */
    }

    public void CameraNextRoom()
    {
        //fade in & out
        cameraPosition.x = Player.transform.position.x;
    }
}
