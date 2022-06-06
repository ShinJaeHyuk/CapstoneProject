using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public Button button;
    public GameObject victorypopup;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(GomainMenu);
    }

    void GomainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
