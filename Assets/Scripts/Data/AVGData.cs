using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DialogData",menuName ="AVG/AVGData")]
public class AVGData : ScriptableObject
{
    public List<DialogContent> contens;
}

[System.Serializable]
public class DialogContent
{
    public string content;
    public bool charaADisplay;
    public bool charaBDisplay;

}
