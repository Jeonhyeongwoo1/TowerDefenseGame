using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    
    public TurretBlueprint turretToBuild;
    public GameObject buildEffect;
    public bool CanBuild { get { return turretToBuild.prefab != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enugh Money to Build That!");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret =  Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        Debug.Log("Turret build Money Left : " + PlayerStats.money);
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuilderManager in Scene !");
            return;
        }
        instance = this;
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
