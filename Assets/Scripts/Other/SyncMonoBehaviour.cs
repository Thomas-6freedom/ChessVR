﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SyncMonoBehaviour : MonoBehaviour, ITransformSync
{
    public string GUID;
    private float timeSinceLastSyncDown;
    private Vector3 lastPos;
    private Quaternion lastRot;
    private Vector3 lastScale;
    
    //only for object created through the editor;
    [ContextMenu("Reset GUID")]
    void Reset()
    {
        if(string.IsNullOrEmpty(GUID))
        {
            GUID = Guid.NewGuid().ToString();
            Debug.Log($"Setting GUID({GUID}) to {name}");
        }
    }

    public void InitializeGUID(string _GUID)
    {
        GUID = _GUID;
    }

    public virtual void SyncTransform(Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        transform.position = _position;
        transform.rotation = _rotation;
        transform.localScale = _scale;
        timeSinceLastSyncDown = Time.time;
    }

    public virtual void Update()
    {
        if (Time.time > timeSinceLastSyncDown + NetworkSynchronizer.Instance.synchroTime) //Synchro Up only if you hasn't been Sync Down recently
        {
            if(lastPos != transform.position || lastRot != transform.rotation || lastScale != transform.localScale)
            {
                NetworkSynchronizer.Instance.SyncUp(this);
            }
        }
    }

    public virtual void LateUpdate()
    {
        lastPos = transform.position;
        lastRot = transform.rotation;
        lastScale = transform.localScale;
    }
}