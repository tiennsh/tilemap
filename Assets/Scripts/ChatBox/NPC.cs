using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Message[] messages;
    public Sprite IconNPC;
    public GameObject ChatBoxPanel;
    

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Va cham Player");
            Player_1.Ins.isChatBox = true;
            ChatBoxPanel.SetActive(true);
            ChatBox.Ins.SetMessage(messages, IconNPC, Player_1.Ins.IconPlayer);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ChatBoxPanel.SetActive(false);
            Player_1.Ins.isChatBox = false;
        }
    }
}
