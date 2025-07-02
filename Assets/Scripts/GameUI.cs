using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public Rotator m_rotator;
    public PlayerController m_playerController;
    public List<TurretController> m_turretControllers = new List<TurretController>();
    public void Init()
    {
        m_playerController.Init();
        foreach (var turret in m_turretControllers)
        {
            turret.Init();
        }
        m_rotator.Init();
    }
    void Start()
    {

    }
    void Update()
    {

    }
    public void StopFire()
    {
        foreach (var turret in m_turretControllers)
        {
            turret.StopFire();
        }
    }
}
