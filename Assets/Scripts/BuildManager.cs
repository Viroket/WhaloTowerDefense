using UnityEngine;
using System.Collections;


public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; // stores a referance to himself
    private TurretBlueprint turretToBuild;
    private bool GotMoneyForTurret;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More then 1 build manager");
        }
        instance = this;
    }
    public GameObject groundTurretPrefab;
    public GameObject airTurretPrefab;

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool GotTheMoney()
    {
        return GotMoneyForTurret;
    }

    public void BuildTurretOn(TurretPivot pivot, GameObject placmentObject)
    {
        if (!PlayerStats.playerState.TryTakeFunds(turretToBuild.cost)) // if it return false it's not taking money out
        {
            GotMoneyForTurret = false;
            Debug.Log("Not enough money");
            return;
        }
        placmentObject.SetActive(false);
        GotMoneyForTurret = true;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, pivot.GetBuildPosition(), Quaternion.identity);
        pivot.turret = turret;

        Debug.Log("Turret build, Money left: " + PlayerStats.playerState.Funds);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
