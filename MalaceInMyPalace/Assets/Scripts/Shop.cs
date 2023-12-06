using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TowerBlueprint arrowTower;
    public TowerBlueprint cannonTower;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArrowTower()
    {
        Debug.Log("Selected arrow tower");
        buildManager.SelectTowerToBuild(arrowTower);
    }
    public void SelectCannonTower()
    {
        Debug.Log("Selected cannon tower");
        buildManager.SelectTowerToBuild(cannonTower);
    }
}
