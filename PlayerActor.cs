using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    Rigidbody2D rigid;

    float h;
    float v;

    public float speed;
    bool isHorizontal;

    Animator anim;

    // 기본적인 변수들
    bool isSlide = false;
    Vector2 sliding;
    Vector2 dir;
    public float slidingSpeed = 300f;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // Check Horizontal Move
        if (hDown)
            isHorizontal = true;
        else if (vDown)
            isHorizontal = false;
        else if (hUp || vUp)
            isHorizontal = h != 0;

        //Animation
        if(anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

    }

    private void FixedUpdate()
    {
        // Move
        Vector2 moveVec = isHorizontal ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        if(isSlide)
        {
            InvokeRepeating("OnSliding", 0f, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SlidingTile")
        {
            /*
            Vector2 direction = (transform.position - collision.transform.position).normalized * Vector2.up;

            Vector2 knockBack = direction * knockbackForce;

            rigid.AddForce(knockBack);
            */
            isSlide = true;
            dir = isHorizontal ? new Vector2(collision.transform.position.x - rigid.transform.position.x,0) 
                : new Vector2(0,(collision.transform.position.y - rigid.transform.position.y)); 
            // 플레이어가 바라보는 방향으로 벡터가 정해짐
            Debug.Log("On Triggered.");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Borderline")
        {
            Debug.Log("Collision with Borderline");
            isSlide = false;
            StopSliding();
        }
    }



    void OnSliding()
    {
        sliding = dir * slidingSpeed;
        rigid.AddForce(sliding);
    }
    void StopSliding()
    {
        CancelInvoke("OnSliding");
    }
}
