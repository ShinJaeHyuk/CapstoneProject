using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<StageManager>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("StageManager");
                    instance = instanceContainer.AddComponent<StageManager>();
                }
            }
            return instance;
        }
    }

    private static StageManager instance;

    public GameObject Player;

    [System.Serializable]

    public class StartPositionArray
    {
        public List<Transform> StartPosition = new List<Transform>();
    }

    public StartPositionArray[] startPositionArrays; //0, 1
    //startpositionarrays[0] 1~10
    //startpositionarrays[1] 11~20
    //방 20개 만들어 각 방의 시작 위치를 입력함

    public List<Transform> StartPositionBoss = new List<Transform>(); // 중간보스방
    public Transform StartPositionLastBoss;

    public int currentStage = 1; //현재 방 위치
    int LastStage = 10; //라스트 보스 방

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void NextStage()
    {
        currentStage++;
        if(currentStage > LastStage)
        {
            return;
        }

        if(currentStage %5 != 0) //normal stage
        {
            int arrayIndex = currentStage / 10;
            int randomIndex = Random.Range(0, startPositionArrays[arrayIndex].StartPosition.Count);
            Player.transform.position = startPositionArrays[arrayIndex].StartPosition[randomIndex].position;
            startPositionArrays[arrayIndex].StartPosition.RemoveAt(randomIndex);
           
        }
        else //bossroom
        {
            if(currentStage == LastStage) //last boss
            {
                Player.transform.position = StartPositionLastBoss.position; 
            }
            else //mid boss
            {
                int randomIndex = Random.Range(0, StartPositionBoss.Count);
                Player.transform.position = StartPositionBoss[randomIndex].position;
                StartPositionBoss.RemoveAt(currentStage / 10);

            }
        }

        //CameraMovement.Instance.CameraNextRoom();
    }
        
}
