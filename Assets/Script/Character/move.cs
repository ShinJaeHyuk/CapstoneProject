using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class move : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static move Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<move>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("move");
                    instance = instanceContainer.AddComponent<move>();
                }
            }
            return instance;
        }
    }

    private static move instance;
    
    public Transform player;
    
    public Transform camPivot;
    public bool isMoving;
    private Joystick controller;

    

    private void Awake()
    {
        controller = this.GetComponent<Joystick>();
        
    }

   /* private void FixedUpdate()
    {
        Vector2 conDir = controller.Direction;
        if (conDir == Vector2.zero) return;

        float thetaEuler = Mathf.Acos(conDir.y / conDir.magnitude) * (180 / Mathf.PI) * Mathf.Sign(conDir.x);

        Vector3 moveAngle = Vector3.up * (camPivot.transform.rotation.eulerAngles.y + thetaEuler);
        player.rotation = Quaternion.Euler(moveAngle);
        player.Translate(Vector3.forward * Time.fixedDeltaTime * PlayerMovement.Instance.moveSpeed);
    }*/

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!PlayerMovement.Instance.Anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            PlayerMovement.Instance.Anim.SetBool("Walk", true);
            PlayerMovement.Instance.Anim.SetBool("Idle", false);
            
        }
        isMoving = true;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 conDir = controller.Direction;
        if (conDir == Vector2.zero) return;

        float thetaEuler = Mathf.Acos(conDir.y / conDir.magnitude) * (180 / Mathf.PI) * Mathf.Sign(conDir.x);

        Vector3 moveAngle = Vector3.up * (camPivot.transform.rotation.eulerAngles.y + thetaEuler);
        player.rotation = Quaternion.Euler(moveAngle);
        player.Translate(Vector3.forward * Time.fixedDeltaTime * PlayerMovement.Instance.moveSpeed);
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!PlayerMovement.Instance.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            PlayerMovement.Instance.Anim.SetBool("Walk", false);
            PlayerMovement.Instance.Anim.SetBool("Idle", true);
            
        }
        isMoving = false;
    }
}
