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

    public GameObject standardTowerPrefab;

    void Start()
    {
        towerToBuild = standardTowerPrefab;
    }

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
