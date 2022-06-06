using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{    public static NextScene Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NextScene>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("NextScene");
                    instance = instanceContainer.AddComponent<NextScene>();
                }
            }
            return instance;
        }
    }

    private static NextScene instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "SampleScene") //test
            {
                SceneManager.LoadScene("Map01");
            }
            else if (SceneManager.GetActiveScene().name == "Map01")
            {
                SceneManager.LoadScene("Map02");
            }
            else if (SceneManager.GetActiveScene().name == "Map02")
            {
                SceneManager.LoadScene("Map03");
            }
            else if (SceneManager.GetActiveScene().name == "Map03")
            {
                SceneManager.LoadScene("Map04");
            }
            else if (SceneManager.GetActiveScene().name == "Map04")
            {
                SceneManager.LoadScene("Map05");
            }
            else if (SceneManager.GetActiveScene().name == "Map05")
            {
                SceneManager.LoadScene("Map06");
            }
            else if (SceneManager.GetActiveScene().name == "Map06")
            {
                SceneManager.LoadScene("Map07");
            }
            else if (SceneManager.GetActiveScene().name == "Map07")
            {
                SceneManager.LoadScene("Map08");
            }

        }
    }
}
