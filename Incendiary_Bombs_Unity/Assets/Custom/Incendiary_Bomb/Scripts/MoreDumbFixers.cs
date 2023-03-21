using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreDumbFixers : MonoBehaviour
{
    public ItemDrop m_itemdrop;

    private void Awake()
    {
        var damtype = m_itemdrop.m_itemData.m_shared.m_damages;
        damtype.m_damage =0;
        damtype.m_blunt =0;
        damtype.m_slash =0;
        damtype.m_pierce =0;
        damtype.m_chop =0;
        damtype.m_pickaxe =0;
        damtype.m_fire =0;
        damtype.m_frost =0;
        damtype.m_lightning =0;
        damtype.m_poison =0;
        damtype.m_spirit =0;
        m_itemdrop.m_itemData.m_shared.m_damages = damtype;
    }
}
