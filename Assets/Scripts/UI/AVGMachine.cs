using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVGMachine : MonoBehaviour
{
    public enum STATE 
    {
        OFF,
        TYPING,
        PAUSED,
        CHOICE,
    }

    //public List<string> contens;
    public Story data;

    public UIPanel panel;

    public AVGAssetConfig team;

    [SerializeField]STATE state;

    bool justEnter;

    [SerializeField]int curline;

    [Range(1, 100)]
    [SerializeField] float textRollSpeed;

    float timer;
    string targerText;

    private void Start()
    {
        //Init();
        justEnter = true;
    }

    private void Update()
    {
        switch (state)
        {
            case STATE.OFF:
                if (justEnter)
                {
                    Init();
                    //Story story2 = Resources.Load<Story>("Story");
                    //data = story2;
                    //LoadCharaTexture(team.charaA, team.charaB);
                    justEnter = false;
                }
                break;
            case STATE.TYPING:
                if (justEnter)
                {
                    ShowUI();
                    LoadText
                    (data.dataArray[curline].Dialogtext, data.dataArray[curline].Charadisplaya.Equals("1"), data.dataArray[curline].Charadisplayb.Equals("1"));
                    justEnter = false;
                }
                CheckAllContent();
                TextEffect();
                break;
            case STATE.PAUSED:
                if (justEnter)
                {
                    timer = 0;
                    justEnter = false;
                }
                break;
            case STATE.CHOICE:
                if (justEnter)
                {
                    panel.ShowButton(true, data.dataArray[curline].Button1text, data.dataArray[curline].Button2text);
                    panel.ButtonName(data.dataArray[curline].Button1msg, data.dataArray[curline].Button2msg);
                    justEnter = false;
                }
                break;
            default:
                break;
        }



        //if (Input.GetKeyDown("1"))
        //{
        //    Init();
        //    LoadCharaTexture(team.charaA, team.charaB);
        //    LoadText
        //        (data.dataArray[curline].Dialogtext,data.dataArray[curline].Charadisplaya.Equals("1"), data.dataArray[curline].Charadisplayb.Equals("1"));
        //    ShowUI();
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    NestText();
        //    if (curline >= data.dataArray.Length)
        //    {
        //        Init();
        //    }
        //    LoadText
        //    (data.dataArray[curline].Dialogtext, data.dataArray[curline].Charadisplaya.Equals("1"), data.dataArray[curline].Charadisplayb.Equals("1"));
        //}
    }


    public void StartMachine()
    {
        if (state == STATE.OFF)
        {
            GoToState(STATE.TYPING);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


    public void UserClick()
    {
        switch (state)
        {
            case STATE.TYPING:
                break;
            case STATE.PAUSED:
                NestText();
                if (curline >= data.dataArray.Length)
                {
                    GoToState(STATE.OFF);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    GoToState(STATE.TYPING);
                }
                break;
            case STATE.CHOICE:
                break;
            default:
                break;
        }

    }

    void GoToState(STATE next)
    {
        state = next;
        justEnter = true;
    }

    void CheckAllContent()
    {
        if ((int)Mathf.Min(Mathf.Floor(timer * textRollSpeed))>=targerText.Length)
        {
            if (data.dataArray[curline].Hasbuttonchoice.Equals("1"))
            {
                GoToState(STATE.CHOICE);
            }
            else
            {
                GoToState(STATE.PAUSED);
            }
        }
    }

    void Init()
    {
        HideUI();
        curline = 0;
        panel.ChangeContenText("");
        panel.ShowButton(false);
    }

    void ShowUI()
    {
        panel.ShowCanvas(true);
    }

    void HideUI()
    {
        panel.ShowCanvas(false);
    }

    void NestText()
    {
        curline++;
    }

    //void LoadText(string value)
    //{
    //    panel.ChangeContenText(value);
    //}

    void LoadText(string value,bool showCharaA,bool showCharaB)
    {
        //panel.ChangeContenText(value);
        targerText = value;
        panel.ShowCharaA(showCharaA);
        panel.ShowCharaB(showCharaB);
    }

    void TextEffect()
    {
        timer += Time.deltaTime;
        panel.ChangeContenText(targerText.Substring(0, (int)Mathf.Min(Mathf.Floor(timer * textRollSpeed), targerText.Length)));
    }


    public void LoadCharaTexture(Texture charaA,Texture charaB)
    {
        panel.ChangeCharaA(charaA);
        panel.ChangeCharaB(charaB);
    }

    public void ProcessButtonMsg(GameObject obj)
    {
        switch (obj.name)
        {
            case "HomeChoice":
                Story story2 = Resources.Load<Story>("Story2");
                data = story2;
                Init();
                GoToState(STATE.TYPING);              
                break;
            case "ShopChoice":
                GameObject.FindGameObjectWithTag("Door").SendMessage("OpenDoor");
                GoToState(STATE.OFF);
                break;
            default:
                break;
        }

    }
}
