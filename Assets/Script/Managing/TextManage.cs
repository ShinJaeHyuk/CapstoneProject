using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManage : MonoBehaviour
{

    //public TMPro.TMP_Text bullettxt;
    //public TMPro.TMP_Text stagetxt;
    public TextMeshProUGUI bullettxt;
    public TextMeshProUGUI stagetxt;
    //public TextMeshProUGUI stagetxt1;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        stagetxt.text = " " + StageManager.Instance.currentStage.ToString();
        bullettxt.text = " " +  PlayerTargeting.Instance.ShootCount.ToString();

        //stagetxt.text = "" + StageManager.Instance.currentStage;
    }
}
