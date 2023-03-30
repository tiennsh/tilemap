using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player_1;
    public CamController mainCam;
    public Arrow arrowPrefab;
    public AxeAtk axeAtkPrefab;
    public TreeRoot treeRootPrefab;
    public TreeSmall treeSmallPrefab;
    public TreeMature treeMaturePrefab;



    bool m_isShoot;
    string m_isItem;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    void Start()
    {
        m_isItem = "axe";
        GameGUIManager.Ins.ShowGameAtk("axe");
    }

    private void Update()
    {
        Lerp();
        if (Input.GetKeyDown(KeyCode.J) && !m_isShoot)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (m_isItem == "axe")
                m_isItem = "bow";
            else if (m_isItem == "bow")
                m_isItem = "axe";
            GameGUIManager.Ins.ShowGameAtk(m_isItem);
        }

    }

    IEnumerator ShootStop()
    {
        yield return new WaitForSeconds(1f);

        m_isShoot = false;
    }

    public void Shoot()
    {
        

        Vector3 xPos = Vector3.zero;
        switch (Player_1.Ins.move_name)
        {
            case "Down":
                {
                    xPos = new Vector3(player_1.transform.position.x,
                        player_1.transform.position.y - 1.05f,
                        player_1.transform.position.z);
                    break;
                }
            case "Right":
                {
                    xPos = new Vector3(player_1.transform.position.x + 0.72f,
                        player_1.transform.position.y,
                        player_1.transform.position.z);
                    break;
                }
            case "Up":
                {
                    xPos = new Vector3(player_1.transform.position.x,
                        player_1.transform.position.y + 0.35f,
                        player_1.transform.position.z);
                    break;
                }
            case "Left":
                {
                    xPos = new Vector3(player_1.transform.position.x - 0.72f,
                        player_1.transform.position.y,
                        player_1.transform.position.z);
                    break;
                }
        }

        if (m_isItem == "bow" && arrowPrefab != null)
        {
            Arrow arrowClone = Instantiate(arrowPrefab, xPos, Quaternion.identity);

            arrowClone.Shoot(Player_1.Ins.move_name);
        }
        else if(m_isItem == "axe" && axeAtkPrefab != null)
        {
            AxeAtk axeAtkClone = Instantiate(axeAtkPrefab, xPos, Quaternion.identity);
        }

        Player_1.Ins.Atk();
        m_isShoot = true;
        StartCoroutine(ShootStop());
    }

    void LerpStop()
    {
        if (player_1.transform.position.x == mainCam.transform.position.x 
            && player_1.transform.position.y == mainCam.transform.position.y)
            mainCam.LerpTriggerStop();
    }

    void Lerp()
    {
        if (mainCam && player_1)
        {
            mainCam.LerpTrigger(player_1.transform.position.x, player_1.transform.position.y);
        }
        if (player_1.transform.position.x == mainCam.transform.position.x
            && player_1.transform.position.y == mainCam.transform.position.y)
            mainCam.LerpTriggerStop();
    }

    public void ShowTreeRoot(Vector3 Pos)
    {
        if(treeRootPrefab)
        {
            TreeRoot treeRootClone = Instantiate(treeRootPrefab, Pos, Quaternion.identity);
        }
    }

    public void ShowTreeSmall(Vector3 Pos)
    {
        if (treeSmallPrefab)
        {
            TreeSmall treeSmallClone = Instantiate(treeSmallPrefab, Pos, Quaternion.identity);
        }
    }

    public void ShowTreeMature(Vector3 Pos)
    {
        if (treeMaturePrefab)
        {
            TreeMature treeMatureClone = Instantiate(treeMaturePrefab, Pos, Quaternion.identity);
        }
    }
}
