using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAtk : Singleton<AxeAtk>
{
    Rigidbody2D m_rb;

    public override void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AxeAtkStop());
    }

    IEnumerator AxeAtkStop()
    {
        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);
    }

}
