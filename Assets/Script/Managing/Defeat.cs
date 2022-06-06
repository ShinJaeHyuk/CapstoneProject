using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Defeat : MonoBehaviour
{
    public Button restartbtn;
    public Button exitbtn;
    public GameObject defeat;
    public TextMeshProUGUI stagetxt;
    public TextMeshProUGUI currentstage;

    // Start is called before the first frame update
    void Start()
    {
        restartbtn.onClick.AddListener(restart);
        exitbtn.onClick.AddListener(exit);
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        stagetxt.text = " " + currentstage.text;

    }
}
