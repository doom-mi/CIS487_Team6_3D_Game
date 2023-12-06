using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
        AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public TowerBlueprint arrowTower;
    public TowerBlueprint cannonTower;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArrowTower()
    {
        audioManager.PlaySFX(audioManager.selectTower);
        Debug.Log("Selected arrow tower");
        buildManager.SelectTowerToBuild(arrowTower);
    }
    public void SelectCannonTower()
    {
        audioManager.PlaySFX(audioManager.selectTower);
        Debug.Log("Selected cannon tower");
        buildManager.SelectTowerToBuild(cannonTower);
    }
}
