using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomCondition : MonoBehaviour
{

    public static RoomCondition Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RoomCondition>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("RoomCondition");
                    instance = instanceContainer.AddComponent<RoomCondition>();
                }
            }
            return instance;
        }
    }

    private static RoomCondition instance;

    List<GameObject> MonsterListInRoom = new List<GameObject>();
    public bool playerInThisRoom = false;
    public bool isClearRoom = false;
    public GameObject nextroom;
    public int monCount;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Map01")
        {
            monCount = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Map02")
        {
            monCount = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Map03")
        {
            monCount = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Map04")
        {
            monCount = 4;
        }
        else if (SceneManager.GetActiveScene().name == "Map05")
        {
            monCount = 6;
        }
        else if (SceneManager.GetActiveScene().name == "Map06")
        {
            monCount = 5;
        }
        else if (SceneManager.GetActiveScene().name == "Map07")
        {
            monCount = 7;
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        if (playerInThisRoom)
        {
            if(monCount==0 && !isClearRoom)
            {
                isClearRoom = true;
            }
            /*
            if (PlayerTargeting.Instance.MonsterList.Count<=0 && !isClearRoom)
            {
                isClearRoom = true;
                Debug.Log("Clear");

            }*/
        }

        if(isClearRoom == true)
        {
            nextroom.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInThisRoom = true;
            PlayerTargeting.Instance.MonsterList = new List<GameObject>(MonsterListInRoom);
            Debug.Log(monCount);
            Debug.Log("Enter room count : " + PlayerTargeting.Instance.MonsterList.Count);

        }
        if (other.CompareTag("Monster"))
        {
            MonsterListInRoom.Add(other.transform.gameObject);
            Debug.Log("name:" + other.transform.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInThisRoom = false;
            PlayerTargeting.Instance.MonsterList.Clear();

        }
        if (other.CompareTag("Monster"))
        {
            MonsterListInRoom.Remove(other.transform.gameObject);
        }
    }
}
