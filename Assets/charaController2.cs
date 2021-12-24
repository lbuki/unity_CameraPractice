using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class charaController2 : MonoBehaviour
{
    GameObject camera;
    Vector3 cameraRot;
    Rigidbody rigid;
    float walkSpeed;
    float jumpForce = 1500f;
    float speedx;
    float speedz;
    float speedy;
    float TotalWalkspeed;
    bool jumpAble = true;

    const float maxWalkSpeed = 20;
    const float Speed = 300f;
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
        speedx = Mathf.Abs(this.rigid.velocity.x);
        speedz = Mathf.Abs(this.rigid.velocity.z);
        speedy = Mathf.Abs(this.rigid.velocity.y);
        TotalWalkspeed = speedx + speedz;
        cameraRot = camera.transform.rotation.eulerAngles;  //カメラの角度（オイラー角）
        cameraRot.x = 0;
        cameraRot.z = 0;                                    //キャラにx,z軸の変更は不要

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))           //↗︎
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 45f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))  //↘︎
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 135f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))  //↙︎
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 225f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))  //↖︎
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 315f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.W))                             //↑
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.S))                              //↓
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 180f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }
        else if(Input.GetKey(KeyCode.A))                               //←
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            walkSpeed = Speed;
            this.transform.Rotate(0, 270f, 0);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.D))                              //→
        {
            this.transform.rotation = Quaternion.Euler(cameraRot);
            this.transform.Rotate(0, 90f, 0);
            walkSpeed = Speed;
            animator.SetBool("isWalking", true);
        }
        else
        {
            walkSpeed *= 0.95f;
            animator.SetBool("isWalking", false);
        }                                             //キャラ移動コード

        
        

        
        //Debug.Log("velo = "+this.rigid.velocity);
        //Debug.Log(jumpAble);
    }
    void FixedUpdate()
    {
        if (TotalWalkspeed < maxWalkSpeed)
        {
            this.rigid.AddForce(transform.forward * this.walkSpeed);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && jumpAble == true)//ジャンプ関係 地面と接触していないと飛べない
        {
            this.rigid.AddForce(transform.up * jumpForce);
            animator.SetTrigger("isJump");
            jumpAble = false;
            //Debug.Log("tonda");
        }
        else if (jumpForce <= 270f)                       //連続で飛ぶと高く飛べない
        {

            //jumpForce += 0.45f;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Field")
        {
            jumpAble = true;
            //Debug.Log("field");
        }
        else
        {
            Debug.Log("air");
            //jumpAble = false;
        }
    }
}
