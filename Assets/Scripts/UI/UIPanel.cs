using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public RawImage characteA;
    public RawImage characteB;
    public Image contentBG;
    public Text contentText;
    public Canvas canvas;

    public GameObject button1;
    public GameObject button2;

    public void ShowButton(bool value)
    {
        button1.SetActive(value);
        button2.SetActive(value);
    }

    public void ShowButton(bool value,string content1,string content2)
    {
        button1.SetActive(value);
        button2.SetActive(value);
        button1.GetComponentInChildren<Text>().text = content1;
        button2.GetComponentInChildren<Text>().text = content2;
    }

    public void ButtonName(string msg1, string msg2)
    {
        button1.name = msg1;
        button2.name = msg2;
    }



    public void ShowCharaA(bool value)
    {
        characteA.enabled = value;
    }
    public void ShowCharaB(bool value)
    {
        characteB.enabled = value;
    }
    public void ShowContentBG(bool value)
    {
        contentBG.enabled = value;
    }
    public void ShowContentText(bool value)
    {
        contentText.enabled = value;
    }
    public void ChangeContenText(string value)
    {
        contentText.text = value;
    }

    public void ShowCanvas(bool value)
    {
        canvas.enabled = value;
    }

    public void ChangeCharaA(Texture charaA)
    {
        characteA.texture = charaA;
    }

    public void ChangeCharaB(Texture charaB)
    {
        characteB.texture = charaB;
    }

}
