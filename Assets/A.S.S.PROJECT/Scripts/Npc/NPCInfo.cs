using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
[Serializable]
public struct NpcIDInfo
{
    public Sprite photoID;
    public string name;
    public string age;
    public string idNumber;
    public string nationality;
    public string antivirus;
    public override string ToString()
    {
        return $"Name:\n {name}\n Age:\n {age}\n ID:\n {idNumber}\n Nationality:\n {nationality}\n Antivirus:\n {antivirus}";
    }
}
[Serializable]
public struct NpcVisaInfo
{
    public Sprite photoID;
    public string reason;
    public string name;
    public string age;
    public string idNumber;
    public string nationality;
    public string antivirus;
    public override string ToString()
    {
        return $"Reason:\n {reason}\n Name:\n {name}\n Age:\n {age}\n ID:\n {idNumber}\n Nationality:\n {nationality}\n antivirus:\n {antivirus}";
    }
}
public class NPCInfo : MonoBehaviour
{
    public NpcIDInfo idInfo;
    public NpcVisaInfo visaInfo;
    public NpcIDInfo GetIDInfo()
    {
        return idInfo;
    }
    public NpcVisaInfo GetVisaInfo()
    {
        return visaInfo;
    }
}
