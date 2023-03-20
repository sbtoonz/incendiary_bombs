using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

#nullable enable
public class BoomCountdown : MonoBehaviour, IProjectile
{
    private ZNetView? m_netview = null!;
    [SerializeField] internal GameObject? m_aoe_explosion_prefab;
    [SerializeField] internal Aoe? m_aoe_script;
    [SerializeField] internal Projectile? m_parent_projectile;
    public float m_timeout = 1f;
    
    private void Awake()
    {
        m_netview = GetComponent<ZNetView>();
    }

    private void OnEnable()
    {
        if (m_aoe_explosion_prefab != null) m_aoe_script = m_aoe_explosion_prefab.GetComponent<Aoe>();
        Trigger();
    }

    public void Trigger() => InvokeRepeating("DestroyNow", m_timeout, 1f);

    public void Trigger(float timeout) => InvokeRepeating("DestroyNow", timeout, 1f);

    private void DestroyNow()
    {
        if (m_netview != null && (bool) (Object) m_netview)
        {
            if (!m_netview.IsValid() || !m_netview.IsOwner())
                return;
            m_aoe_explosion_prefab = Instantiate(m_aoe_explosion_prefab, transform.position, transform.rotation);
            ZNetScene.instance.Destroy(gameObject);
            
        }
        else
            m_aoe_explosion_prefab = Instantiate(m_aoe_explosion_prefab, transform.position, transform.rotation);
        Destroy((Object) gameObject);
    }



    public void Setup(Character owner, Vector3 velocity, float hitNoise, HitData hitData, ItemDrop.ItemData item, ItemDrop.ItemData ammo)
    {
        if (m_aoe_script != null) m_aoe_script.Setup(owner, velocity, hitNoise, hitData, item, ammo);
    }

    public string GetTooltipString(int itemQuality)
    {
        return "";
    }
}
