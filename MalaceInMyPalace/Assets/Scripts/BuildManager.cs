using TowerDefense.Towers;
using UnityEngine;
using UnityEngine.UI;

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
    private PlaceTower selectedTower;

    public PlacematUI placematUI;

    public bool CanBuild { get { return towerToBuild != null; } }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        DeselectPlacement();
    }

    public void SelectPlacemat(PlaceTower spot)
    {
        if(selectedTower == spot)
        {
            DeselectPlacement();
            return;
        }
        selectedTower = spot;
        towerToBuild = null;

        placematUI.SetTarget(spot);
    }

    public void DeselectPlacement() 
    {
        selectedTower = null;
        placematUI.Hide();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }
}
