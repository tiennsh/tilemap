using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSmall : Singleton<TreeSmall>
{
    Rigidbody2D m_rb;
    public int timeSwap;

    int m_timeSwap;

    public override void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_timeSwap = timeSwap;
        StartCoroutine(ReducedTime());
    }

    void Update()
    {
        if (m_timeSwap == 0)
        {
            Vector3 xPos = new Vector3(
                            transform.position.x - 0.5f,
                            transform.position.y,
                            transform.position.z
                            );
            GameManager.Ins.ShowTreeMature(xPos);
            Destroy(gameObject);
        }
    }

    IEnumerator ReducedTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            m_timeSwap--;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("AxeAtk"))
        {

            Vector3 xPos = new Vector3(
                            transform.position.x,
                            transform.position.y,
                            transform.position.z
                            );
            Destroy(gameObject);

            GameManager.Ins.ShowTreeRoot(xPos);

        }
    }
}
