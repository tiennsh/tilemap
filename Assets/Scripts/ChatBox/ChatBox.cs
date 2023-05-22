using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : Singleton<ChatBox>
{
    public Message[] messages;
    public Image IconNPC;
    public Image IconPlayer;
    public TextMeshProUGUI NPCText;
    public TextMeshProUGUI PlayerText;
    public GameObject ChatBoxPanel;

    int indexMessage ;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public virtual void SetMessage(Message[] m_messages, Sprite m_IconNPC, Sprite m_IconPlayer)
    {
        Debug.Log("Message");
        indexMessage = 0;
        messages = m_messages;
        if (IconNPC) IconNPC.sprite = m_IconNPC;
        if (IconPlayer) IconPlayer.sprite = m_IconPlayer;
    }

    public virtual void NextMessage()
    {
        Debug.Log("NextMessage");
        if (indexMessage == messages.Length)
        {
            ChatBoxPanel.SetActive(false);
            Time.timeScale = 1f;
            return;
        }

        if (messages[indexMessage].speaker =="NPC" )
        {
            PlayerText.text = "";
            NPCText.text = messages[indexMessage].message.ToString();
        }
        else
        {
            PlayerText.text = messages[indexMessage].message.ToString();
        }
        indexMessage++;
    }

}
