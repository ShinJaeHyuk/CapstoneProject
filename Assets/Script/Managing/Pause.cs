using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static Pause Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Pause>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("Pause");
                    instance = instanceContainer.AddComponent<Pause>();
                }
            }
            return instance;
        }
    }

    private static Pause instance;

    public Button pausebtn;
    public Button playbtn;
    public Button openbtn;
    public GameObject pausemenu;

    public bool ispause;

    // Start is called before the first frame update
    void Start()
    {
        pausebtn.onClick.AddListener(stop);
        playbtn.onClick.AddListener(play);
        openbtn.onClick.AddListener(goOpen); //go to openscene
        ispause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void stop()
    {
        if (ispause == false)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0;
            ispause = true;
            return;
        }
    }
    void play()
    {
        if (ispause == true)
        {
            pausemenu.SetActive(false);
            Time.timeScale = 1;
            ispause = false;
            return;
        }
    }

    void goOpen()
    {
        pausemenu.SetActive(false);
        SceneManager.LoadScene("OpenScene");
    }
    
}
