using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 20.0f;
    private Rigidbody rbd;
    [SerializeField]
    private float jumpForce = 20.0f;
    [SerializeField]
    private GameObject restartPosition;
    [SerializeField]
    private bool resetLevel;

    public GameObject cam;
    Vector3 fwd;
    Vector3 rgt;

    private bool canJump = false;

    private void Start()
    {
        fwd = cam.transform.forward;
        rgt = cam.transform.right;
        fwd.y = 0f;
        rgt.y = 0f;
        fwd.Normalize();
        rgt.Normalize();
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        fwd = cam.transform.forward;
        rgt = cam.transform.right;
        fwd.y = 0f;
        rgt.y = 0f;
        fwd.Normalize();
        rgt.Normalize();
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveDirection = fwd*moveY + rgt*moveX;
        rbd.AddForce(moveDirection * moveSpeed);
        //MoveWithForce();
        //FixRotation();
        if ((Input.GetKeyDown(KeyCode.Space)) && canJump == true)
        {
            rbd.AddForce(Vector3.up * jumpForce);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "reset")
        {
            if (resetLevel == false)
            {
                transform.position = restartPosition.transform.position;
                rbd.Sleep();
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

}
