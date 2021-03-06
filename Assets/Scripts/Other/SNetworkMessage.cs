﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SNetworkMessage
{
    public int clientID;
    public EMessageType type;
    public string JSON;

    public SNetworkMessage(EMessageType _type, string _json)
    {
        type = _type;
        JSON = _json;
        clientID = int.MinValue;
    }
}


[System.Serializable]
public enum EMessageType
{
    Unknown,
    UpdateTransform,
    Instantiate,
    ConnectionSuccessful,

    //only for Chess
    Grab,
    Ungrab,
    UpdateGrab,
    UpdateHand,
}

[System.Serializable]
public struct SMessageInstantiate
{
    public string GUID;
    public string prefabName;
    public Vector3 position;
    public Quaternion rotation;
    public string parentName; //should be a unique name of a unique gameObject in the scene

    public SMessageInstantiate(string _prefabName, Vector3 _position, Quaternion _rotation, string _parentName)
    {
        GUID = null;
        prefabName = _prefabName;
        position = _position;
        rotation = _rotation;
        parentName = _parentName;
    }
}

[System.Serializable]
public struct SMessageUpdateTransform
{
    public string GUID;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public SMessageUpdateTransform(string _GUID, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        GUID = _GUID;
        position = _position;
        rotation = _rotation;
        scale = _scale;
    }
}

[System.Serializable]
public struct SMessageVector3
{
    public string GUID;
    public Vector3 vector;

    public SMessageVector3(string _GUID, Vector3 _vector)
    {
        GUID = _GUID;
        vector = _vector;
    }
}

[System.Serializable]
public struct SMessageHand
{
    public int ownerClientID;
    public int handType; //0 = left, 1 = right
    public List<SBone> bones;
    public Vector3 position;
    public Quaternion rotation;

    public SMessageHand(int _handType, List<SBone> _bones, Vector3 _pos, Quaternion _rot)
    {
        ownerClientID = int.MinValue;
        handType = _handType;
        bones = _bones;
        position = _pos;
        rotation = _rot;
    }
}

[System.Serializable]
public struct SBone
{
    public string name;
    public Quaternion rotation;

    public SBone(string _str, Quaternion _v)
    {
        name = _str;
        rotation = _v;
    }
}
