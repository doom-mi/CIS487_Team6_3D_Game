using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseArrowTower()
    {
        Debug.Log("Selected arrow tower");
        buildManager.SetTowerToBuild(buildManager.arrowTowerPrefab);
    }
    public void PurchaseCannonTower()
    {
        Debug.Log("Selected cannon tower");
        buildManager.SetTowerToBuild(buildManager.cannonTowerPrefab);
    }
}
