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

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
}
