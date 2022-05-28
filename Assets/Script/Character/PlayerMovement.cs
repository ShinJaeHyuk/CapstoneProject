using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PlayerMovement>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("PlayerMovement");
                    instance = instanceContainer.AddComponent<PlayerMovement>();
                }
            }
            return instance;
        }
    }

    private static PlayerMovement instance;

    Rigidbody rigid;
    public float moveSpeed = 5.0f;
    public Animator Anim;

    public bool isDamage;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(JoyStickMovement.Instance.joyVec.x != 0 || JoyStickMovement.Instance.joyVec.y != 0)
        {
            rigid.velocity = new Vector3(JoyStickMovement.Instance.joyVec.x, 0, JoyStickMovement.Instance.joyVec.y) * moveSpeed;

            rigid.rotation = Quaternion.LookRotation(new Vector3(JoyStickMovement.Instance.joyVec.x, 0, JoyStickMovement.Instance.joyVec.y));
        }

        if (PlayerHpBar.Instance.currentHp == 0)
        {
            Anim.SetTrigger("doDie");

            Invoke("GameOver", 3);

        }
    }

    void GameOver()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("NextRoom"))
        {
            Debug.Log("NextRoom");
            StageManager.Instance.NextStage();
        }
        else if(other.tag == "enemybolt")
        {
            if (!isDamage)
            {
                PlayerHpBar.Instance.currentHp -= Enemy.Instance.enemyboltDmg;
                Destroy(other.gameObject);
                StartCoroutine(OnDamage());
            }
            
        }
        else if(other.tag == "MeleeAtk")
        {
            if (!isDamage)
            {
                PlayerHpBar.Instance.currentHp -= Enemy.Instance.enemyboltDmg;
                StartCoroutine(OnDamage());
            }
        }

        IEnumerator OnDamage()
        {
            isDamage = true;

            yield return new WaitForSeconds(1f);

            isDamage = false;
        }
        
    }

    
}
