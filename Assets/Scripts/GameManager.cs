using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public CamController mainCam;
    public Arrow arrowPrefab;
    public AxeAtk axeAtkPrefab;
    public TreeRoot treeRootPrefab;
    public TreeSmall treeSmallPrefab;
    public TreeMature treeMaturePrefab;
    public MobsBat[] mobsBats;
    public GameObject ChatBoxPanel;

    bool m_isShoot;
    string m_isItem;
    

    public override void Awake()
    {
        MakeSingleton(false);
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!Player_1.Ins.isChatBox) return;
            Time.timeScale = 0f;
            ChatBoxPanel.SetActive(true);
            ChatBox.Ins.NextMessage();
        }

    }

    IEnumerator ShootStop()
    {
        yield return new WaitForSeconds(1f);

        m_isShoot = false;
    }

    IEnumerator ReducedTime(Vector3 pos, int move_name, int timeSwap)
    {
        yield return new WaitForSeconds(timeSwap);

        if (mobsBats != null)
        {
            MobsBat arrowMobsBat = Instantiate(mobsBats[move_name], pos, Quaternion.identity);
        }
    }

    public void SwapMobsBat(Vector3 pos, int move_name, int timeSwap)  //Tạo quái sau XXs
    {
        StartCoroutine(ReducedTime(pos, move_name, timeSwap));
    }


    public void Shoot()
    {
        

        Vector3 xPos = Vector3.zero;
        switch (Player_1.Ins.move_name)
        {
            case "Down":
                {
                    xPos = new Vector3(Player_1.Ins.transform.position.x,
                        Player_1.Ins.transform.position.y - 1.05f,
                        Player_1.Ins.transform.position.z);
                    break;
                }
            case "Right":
                {
                    xPos = new Vector3(Player_1.Ins.transform.position.x + 0.72f,
                        Player_1.Ins.transform.position.y,
                        Player_1.Ins.transform.position.z);
                    break;
                }
            case "Up":
                {
                    xPos = new Vector3(Player_1.Ins.transform.position.x,
                        Player_1.Ins.transform.position.y + 0.35f,
                        Player_1.Ins.transform.position.z);
                    break;
                }
            case "Left":
                {
                    xPos = new Vector3(Player_1.Ins.transform.position.x - 0.72f,
                        Player_1.Ins.transform.position.y,
                        Player_1.Ins.transform.position.z);
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

    void Lerp()
    {
        if (mainCam != null)
        {
            mainCam.LerpTrigger(Player_1.Ins.transform.position.x, Player_1.Ins.transform.position.y);
        }
        if (Player_1.Ins.transform.position.x == mainCam.transform.position.x
            && Player_1.Ins.transform.position.y == mainCam.transform.position.y)
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
