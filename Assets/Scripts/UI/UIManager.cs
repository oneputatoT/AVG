using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AVGMachine machine;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            machine.UserClick();
        }
    }


    public void StartAVG(Story data,AVGAssetConfig asset)
    {
        machine.data = data;
        machine.LoadCharaTexture(asset.charaA, asset.charaB);
        machine.StartMachine();
    }
}
