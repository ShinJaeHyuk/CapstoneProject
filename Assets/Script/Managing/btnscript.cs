using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnscript : MonoBehaviour
{
    public Button Gomapbtn;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = Gomapbtn.GetComponent<Button>();
        btn.onClick.AddListener(Gomap);
    }

    void Gomap()
    {
        Debug.Log("click");
        SceneManager.LoadScene("Map01");
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
