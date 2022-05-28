using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInThisRoom)
        {
            if (PlayerTargeting.Instance.MonsterList.Count<=0 && !isClearRoom)
            {
                isClearRoom = true;
                Debug.Log("Clear");

            }
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
            Debug.Log("Enter room count : " + PlayerTargeting.Instance.MonsterList.Count);

        }
        if (other.CompareTag("Monster"))
        {
            MonsterListInRoom.Add(other.gameObject);
            Debug.Log("name:" + other.gameObject.name);
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
            MonsterListInRoom.Remove(other.transform.parent.gameObject);
        }
    }
}
