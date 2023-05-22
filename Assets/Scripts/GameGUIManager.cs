using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject axeAtkBtn;
    public GameObject bowAtkBtn;
    public GameObject potAtkBtn;
    public GameObject potWaterAtkBtn;
    public GameObject BagInventory;

    bool isShowBag;

    public override void Awake()
    {
        MakeSingleton(false);
        isShowBag = false;
    }

    public void ShowBag()
    {
        isShowBag = !isShowBag;
        BagInventory.SetActive(isShowBag);
        
    }

    public void ShowGameAtk(string m_isAtk)
    {
        if(axeAtkBtn)
        {
            axeAtkBtn.SetActive(false);
            if(m_isAtk == "axe")
                axeAtkBtn.SetActive(true);
        }
            
        if(bowAtkBtn)
        {
            bowAtkBtn.SetActive(false);
            if (m_isAtk == "bow")
                bowAtkBtn.SetActive(true);
        }
            
        if (potAtkBtn)
        {
            potAtkBtn.SetActive(false);
            if (m_isAtk == "pot")
                potAtkBtn.SetActive(true);
        }
        if (potWaterAtkBtn)
        {
            potAtkBtn.SetActive(false);
            if (m_isAtk == "potWater")
                potAtkBtn.SetActive(true);
        }
    }
}
