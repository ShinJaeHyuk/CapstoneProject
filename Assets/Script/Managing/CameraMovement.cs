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
    public float offsetX = 0f;
    public float offsetY = 7f;
    public float offsetZ = -9f;

    Vector3 cameraPosition;
    Vector3 PlayerPos;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void LateUpdate()
    {
        PlayerPos = new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, Player.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, PlayerPos, Time.deltaTime * 2f);
    }

    public void CameraNextRoom()
    {
        //fade in & out
        cameraPosition.x = Player.transform.position.x;
    }
}
