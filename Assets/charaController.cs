using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaController : MonoBehaviour
{
    GameObject camera;
    Vector3 cameraRot;
    Rigidbody rigid;
    float walkSpeed;
    const float Speed = 0.03f;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        this.camera = GameObject.Find("Main Camera");
        animator = GetComponent<Animator>();
        this.rigid = GetComponent<Rigidbody>();
        walkSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cameraRot = camera.transform.rotation.eulerAngles;  //カメラの角度（オイラー角）
        cameraRot.x = 0;
        cameraRot.z = 0;                                    //キャラにx,z軸の変更は不要

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))           //↗︎
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 45f, 0);
            walkSpeed = 0.03f;
            animator.SetBool("isWalking", true);
        }else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))  //↘︎
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 135f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))  //↙︎
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 225f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))  //↖︎
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 315f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }else if (Input.GetKey(KeyCode.W))                             //↑
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }else if (Input.GetKey(KeyCode.S))                              //↓
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 180f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }else if(Input.GetKey(KeyCode.A))                               //←
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            walkSpeed = Speed;
            this.transform.Rotate(0, 270f, 0);
            animator.SetBool("isWalking", true);
        }else if (Input.GetKey(KeyCode.D))                              //→
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 90f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }else
        {
            walkSpeed *= 0.9f;
            animator.SetBool("isWalking", false);
        }
        if(walkSpeed <= 0.000001f)
        {
            walkSpeed = 0.0000f;
        }
        transform.position += transform.forward * walkSpeed;          //キャラ移動コード
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (-1 < this.rigid.velocity.y && this.rigid.velocity.y < 1)
            {
                this.rigid.AddForce(transform.up * 300f);
            }
        }
        Debug.Log(this.walkSpeed);
    }
}
