using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turrentToBuild;
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

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
    
    public void SetTurretToBuild(GameObject turret)
    {
        turrentToBuild = turret;
    }
    
    public GameObject GetTurretToBuild()
    {
        return turrentToBuild;
    }

}
