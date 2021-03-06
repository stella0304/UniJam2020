﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageFactory : MonoBehaviour
{
    private float MAX_TEXT_WIDTH = 180;
    private int TEXTBOX_PADDING = 15;

    public int msgCount;
    public GameObject chatPanel, playerWrapper, replyWrapper, sysWrapper;
    public InputField chatBox;

    // Start is called before the first frame update
    void Start()
    {
        msgCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // sends text to messenger UI depending on who is replying
    public void SendMessageToChat(string text, string player)
    {
        GameObject newMsg = new GameObject();

        if (player.Equals("p1"))
        {
            newMsg = Instantiate(playerWrapper, chatPanel.transform);
            SoundManagerScript.PlaySound("sendText");
        }
        else if (player.Equals("NPC"))
        {
            newMsg = Instantiate(replyWrapper, chatPanel.transform);
            SoundManagerScript.PlaySound("receiveText");
        }
        else if (player.Equals("system"))
        {
            newMsg = Instantiate(sysWrapper, chatPanel.transform);
        }
        else
        {
            UnityEngine.Debug.Log("non-valid player input. Player " + player + " does not exist");
        }

        // get child text object of the wrapper and set text
        newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;

        if (player.Equals("p1") || player.Equals("NPC"))
        {
            resizeMsg(newMsg);
        }
        //else
        //{
        //    // set wrapper's dimensions to text height
        //    float textHeight = newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().preferredHeight;
        //    float origWrapperWidth = newMsg.GetComponent<RectTransform>().sizeDelta.x;
        //    newMsg.GetComponent<RectTransform>().sizeDelta = new Vector2(origWrapperWidth, textHeight + 20);
        //}

        // set wrapper's dimensions to text height
        float textHeight = newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().preferredHeight;
        float origWrapperWidth = newMsg.GetComponent<RectTransform>().sizeDelta.x;
        newMsg.GetComponent<RectTransform>().sizeDelta = new Vector2(origWrapperWidth, textHeight + TEXTBOX_PADDING);

        // newMessage.textObject.text = newMessage.text;
        msgCount += 1;
    }

    private void resizeMsg(GameObject newMsg)
    {
        float textHeight = newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().preferredHeight;

        float textWidth = newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().preferredWidth;

        if (textWidth > MAX_TEXT_WIDTH)
        {
            textWidth = MAX_TEXT_WIDTH;
            leftJustify(newMsg);
        }

        // set background coloured container size to textbox size
        newMsg.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth + 15, textHeight + 15);
    }

    private void leftJustify(GameObject newMsg)
    {
        newMsg.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().alignment = TextAlignmentOptions.TopLeft;
    }

}