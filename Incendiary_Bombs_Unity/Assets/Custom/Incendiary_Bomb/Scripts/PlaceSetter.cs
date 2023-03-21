using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSetter : MonoBehaviour
{
    public Transform m_transformToSet;

    private void Awake()
    {
        var quaternion = m_transformToSet.rotation;
        quaternion.x = 0;
        quaternion.y = 0;
        quaternion.z = 0;
        quaternion.w = 0;
        m_transformToSet.rotation = quaternion;
    }
    private void Start()
    {
        var quaternion = m_transformToSet.rotation;
        quaternion.x = 0;
        quaternion.y = 0;
        quaternion.z = 0;
        quaternion.w = 0;
        m_transformToSet.rotation = quaternion;
    }
}
