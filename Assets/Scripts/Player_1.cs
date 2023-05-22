using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_1 : Singleton<Player_1>
{
    public float moveSpeed;

    Rigidbody2D m_rb;

    Animator m_amin;

    bool atk;
    public string move_name = "Down";
    public Sprite IconPlayer;
    

    public override void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_amin = GetComponent<Animator>();
    }


    void Update()
    {
        if(!atk)
            MoveHandle();

    }

    IEnumerator AtkStop()
    {
        yield return new WaitForSeconds(0.5f);

        atk = false;
        m_amin.SetBool("Atk", false);
    }

    void MoveHandle()
    {
        if (m_amin)
        {
            m_amin.SetBool("Down", false);
            m_amin.SetBool("Right", false);
            m_amin.SetBool("Up", false);
            m_amin.SetBool("Left", false);
        }
        if (GamePadsController.Ins.CanMoveLeft)
        {
            if (m_rb)
        
                transform.position = new Vector3(
            transform.position.x - moveSpeed * Time.deltaTime,
            transform.position.y,
            transform.position.y
            );

            if (m_amin)
                m_amin.SetBool("Left", true);
            move_name = "Left";
        }
        else if (GamePadsController.Ins.CanMoveRight)
        {
            if (m_rb)
                transform.position = new Vector3(
            transform.position.x + moveSpeed * Time.deltaTime,
            transform.position.y,
            transform.position.y
            );

            if (m_amin)
                m_amin.SetBool("Right", true);
            move_name = "Right";
        }
        else if (GamePadsController.Ins.CanMoveUp)
        {
            if (m_rb)
                transform.position = new Vector3(
             transform.position.x ,
             transform.position.y + moveSpeed * Time.deltaTime,
             transform.position.y
             );

            if (m_amin)
                m_amin.SetBool("Up", true);
            move_name = "Up";
        }
        else if (GamePadsController.Ins.CanMoveDown)
        {
            if (m_amin)
            {
                m_amin.SetBool("Down", true);
            }    

            if (m_rb)
                transform.position = new Vector3(
            transform.position.x ,
            transform.position.y - moveSpeed * Time.deltaTime,
            transform.position.y
            );
            move_name = "Down";
        }
    }

    public void Atk()
    {
        atk = true;
        if (m_amin)
        {
            m_amin.SetBool("Atk", true);
        }
        StartCoroutine(AtkStop());
            
    }

    
}
