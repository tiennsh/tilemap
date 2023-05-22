using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsBat : Singleton<MobsBat>
{
    public float moveSpeed;

    public int move_name;

    public int lerpTime;

    public bool isArrow = false;

    public int timeSwap;

    Rigidbody2D m_rb;

    Animator m_amin;

    int m_move;
    public override void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_amin = GetComponent<Animator>();
        m_move = move_name;
    }

    private void Update()
    {
        if (m_move == 4)
            m_move = 4;
        else if (transform.position.x < 3)
            m_move = 2;
        else if (transform.position.x > 9)
            m_move = 3;
        else if (transform.position.y < 6)
            m_move = 1;
        else if (transform.position.y > 11)
            m_move = 0;
        MoveBat();
        if (isArrow)
            MoveLerp();
    }

    void MoveBat()
    {
         if (m_amin)
            {
                m_amin.SetBool("Down", false);
                m_amin.SetBool("Right", false);
                m_amin.SetBool("Up", false);
                m_amin.SetBool("Left", false);
            }
        if(m_move == 2)
        {
            if (m_rb)
                transform.position = new Vector3(
            transform.position.x + moveSpeed * Time.deltaTime,
            transform.position.y,
            transform.position.y
            );

            if (m_amin)
                m_amin.SetBool("Right", true);
        }
        else if(m_move == 3)
        {
            if (m_rb)

                transform.position = new Vector3(
            transform.position.x - moveSpeed * Time.deltaTime,
            transform.position.y,
            transform.position.y
            );

            if (m_amin)
                m_amin.SetBool("Left", true);
        }
        else if (m_move == 1)
        {
            if (m_rb)
                transform.position = new Vector3(
             transform.position.x,
             transform.position.y + moveSpeed * Time.deltaTime,
             transform.position.y
             );

            if (m_amin)
                m_amin.SetBool("Up", true);
        }
        else if (m_move == 0)
        {
            if (m_amin)
            {
                m_amin.SetBool("Down", true);
            }

            if (m_rb)
                transform.position = new Vector3(
            transform.position.x,
            transform.position.y - moveSpeed * Time.deltaTime,
            transform.position.y
            );
        }
        else if (m_move == 4)
            if (m_amin)
            {
                m_amin.SetBool("Ide", true);
            }
    }

    void MoveLerp()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        xPos = Mathf.Lerp(xPos, Player_1.Ins.transform.position.x, lerpTime * Time.deltaTime);
        yPos = Mathf.Lerp(yPos, Player_1.Ins.transform.position.y, lerpTime * Time.deltaTime);
        transform.position = new Vector3(xPos, yPos, transform.position.z);

    }

    public void CheckArrow()
    {
        isArrow = true;
        GameManager.Ins.SwapMobsBat(transform.position, move_name, timeSwap);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (m_move ==4)
                Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Arrow"))
        {
            if (m_move != 4)
            {
                m_move = 4;
                MoveBat();
                Invoke("CheckArrow", 2f);
                Destroy(col.gameObject);
            }
            
        }
    }
}
