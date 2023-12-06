using TowerDefense.Towers;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {   
        if(instance != null)
        {
            Debug.LogError("More than one build manager in scene!");
            return;
        }

        instance = this;
    }

    public GameObject arrowTowerPrefab;
    public GameObject cannonTowerPrefab;

    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null; } }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }

    public void BuildTowerOn(PlaceTower tile)
    {
        if(PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Not enough money to build that! TODO: DISPLAY TO USER");
            return;
        }

       PlayerStats.Money -= towerToBuild.cost;
       GameObject tower = Instantiate(towerToBuild.prefab, tile.GetTilePosition(), Quaternion.identity);
       tile.tower = tower;

        Debug.Log("Tower built! Money left: " + PlayerStats.Money);
    }
}
