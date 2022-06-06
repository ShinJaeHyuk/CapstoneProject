using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public Button mainbtn;
    

    // Start is called before the first frame update
    void Start()
    {
        mainbtn.onClick.AddListener(GotoMainmenu);
        
    }

    void GotoMainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
