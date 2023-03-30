using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMature : Singleton<TreeMature>
{
    Rigidbody2D m_rb;

    public override void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("AxeAtk"))
        {
            
            Vector3 xPos = new Vector3(
                            transform.position.x + 0.5f,
                            transform.position.y,
                            transform.position.z
                            );
            Debug.Log(xPos);
            Destroy(gameObject);

            GameManager.Ins.ShowTreeRoot(xPos);

        }
    }
}
