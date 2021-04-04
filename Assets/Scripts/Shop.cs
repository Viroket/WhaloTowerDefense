using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint groundTurest;
    public TurretBlueprint AirTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectGroundTurret()
    {
        Debug.Log("Ground Turret Selected");
        buildManager.SelectTurretToBuild(groundTurest);
    }
    public void SelectAirTurret()
    {
        Debug.Log("Air Turret Selected");
        buildManager.SelectTurretToBuild(AirTurret);
    }
}
