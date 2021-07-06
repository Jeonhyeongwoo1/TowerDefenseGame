using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject laserBeamerPrefab;
    public NodeUI nodeUI;

    private TurretBlueprint turretToBuild;
    public GameObject buildEffect;
    public bool CanBuild
    {
        get
        {
            if (turretToBuild != null)
            {
                return turretToBuild.prefab != null;
            }
            else
            {
                return false;
            }
        }
    }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    private Node selectedNode;

    public void BuildTurretOn(Node node)
    {
       
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

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
