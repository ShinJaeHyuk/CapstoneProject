using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    
    public float offsetX;

    public float offsetY;
    public float offsetZ;
        
    public Vector3 PlayerPos;
    // Start is called before the first frame update

    private void Start()
    {
        
    }
    // Update is called once per frame
    /*void LateUpdate()
    {
        
        PlayerPos = new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, Player.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, PlayerPos, Time.deltaTime * 2f);
    }
    */

    private void FixedUpdate()
    {
        Vector3 pos = new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, Player.transform.position.z + offsetZ);
        this.transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f);
    }


}
