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
    [SerializeField] internal GameObject? terraform;
    [SerializeField] internal Aoe? m_aoe_script;
    [SerializeField] internal Projectile? m_parent_projectile;
    [SerializeField] internal SnapToGround? m_snappable;
    [SerializeField] internal bool isSticky;
    public float m_timeout = 1f;
    
    private void Awake()
    {
        m_netview = GetComponent<ZNetView>();
    }

    private void OnEnable()
    {
        if (m_aoe_explosion_prefab != null) m_aoe_script = m_aoe_explosion_prefab.GetComponent<Aoe>();
        switch (isSticky)
        {
            case false:
                m_snappable!.Snap();
                break;
            case true:
            {
                var rb = gameObject.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                Collider[] hits = Physics.OverlapSphere(transform.position, 10);
                foreach (var hit in hits)
                {
                    if (hit.gameObject.GetComponent<Player>())
                    {
                        if(hit.gameObject.GetComponent<Player>() == Player.m_localPlayer) continue;
                    }
                    if (hit.gameObject.GetComponent<Rigidbody>())
                    {
                        this.transform.SetParent(hit.gameObject.transform);
                        var pos =hit.GetComponentInChildren<MeshRenderer>().bounds.ClosestPoint(this.transform.position);
                        this.transform.position = pos;
                    }
                }

                break;
            }
        }

        Trigger();
    }

    public void Trigger() => InvokeRepeating(nameof(DestroyNow), m_timeout, 1f);

    public void Trigger(float timeout) => InvokeRepeating("DestroyNow", timeout, 1f);

    private void DestroyNow()
    {
        if (m_netview != null && (bool) (Object) m_netview)
        {
            if (!m_netview.IsValid() || !m_netview.IsOwner())
                return;
            m_aoe_explosion_prefab = Instantiate(m_aoe_explosion_prefab, transform.position, transform.rotation);
            terraform = Instantiate(terraform, transform.position, transform.rotation);
            ZNetScene.instance.Destroy(gameObject);
            
        }
        else
        {
            m_aoe_explosion_prefab = Instantiate(m_aoe_explosion_prefab, transform.position, transform.rotation);
            terraform = Instantiate(terraform, transform.position, transform.rotation);

            Destroy((Object)gameObject);
        }
    }



    public void Setup(Character owner, Vector3 velocity, float hitNoise, HitData hitData, ItemDrop.ItemData item, ItemDrop.ItemData ammo)
    {
        switch (isSticky)
        {
            case true:
                m_aoe_script.m_damage.m_chop = 15;
                m_aoe_script.m_damage.m_blunt = 15;
                m_aoe_script.m_damage.m_fire = 15;
                m_aoe_script.m_useAttackSettings = true;
                break;
            case false:
                m_aoe_script.m_damage.m_chop = 5;
                m_aoe_script.m_damage.m_blunt = 5;
                m_aoe_script.m_damage.m_fire = 15;
                m_aoe_script.m_useAttackSettings = true;
                break;
        }
        if (m_aoe_script != null) m_aoe_script.Setup(owner, velocity, hitNoise, hitData, item, ammo);
    }

    public string GetTooltipString(int itemQuality)
    {
        return "";
    }
}