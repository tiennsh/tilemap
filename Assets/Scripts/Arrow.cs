using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Singleton<Arrow>
{
    public float moveSpeed;

    Rigidbody2D m_rb;

    string move_direction;

    

    public override void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(move_direction != null)
        {
            switch (move_direction)
            {
                case "Down":
                    {
                        if (m_rb)
                        {
                            transform.rotation = Quaternion.Euler(0, 0, 45);
                            transform.position = new Vector3(
                            transform.position.x,
                            transform.position.y - moveSpeed * Time.deltaTime,
                            transform.position.z
                            );
                        }
                            
                        break;
                    }
                case "Right":
                    {
                        if (m_rb)
                        {
                            transform.rotation = Quaternion.Euler(0, 0, 135);
                            transform.position = new Vector3(
                            transform.position.x + moveSpeed * Time.deltaTime,
                            transform.position.y,
                            transform.position.z
                            );
                        }
                            
                        break;
                    }
                case "Up":
                    {
                        if (m_rb)
                        {
                            transform.rotation = Quaternion.Euler(0, 0, 225);
                            transform.position = new Vector3(
                            transform.position.x,
                            transform.position.y + moveSpeed * Time.deltaTime,
                            transform.position.z
                            );
                        }
                        break;
                    }
                case "Left":
                    {
                        if (m_rb)
                        {
                            transform.rotation = Quaternion.Euler(0, 0, 315);
                            transform.position = new Vector3(
                        transform.position.x - moveSpeed * Time.deltaTime,
                        transform.position.y,
                        transform.position.z
                        );
                        }
                            
                        break;
                    }


            }
        }
    }

    

    public void Shoot(string direction)
    {
        move_direction = direction;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(!col.gameObject.CompareTag("Player"))
            Destroy(gameObject);
            
    }

}
