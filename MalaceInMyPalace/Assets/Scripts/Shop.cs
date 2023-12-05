using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
        AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseArrowTower()
    {
        audioManager.PlaySFX(audioManager.selectTower);
        Debug.Log("Selected arrow tower");
        buildManager.SetTowerToBuild(buildManager.arrowTowerPrefab);
    }
    public void PurchaseCannonTower()
    {
        audioManager.PlaySFX(audioManager.selectTower);
        Debug.Log("Selected cannon tower");
        buildManager.SetTowerToBuild(buildManager.cannonTowerPrefab);
    }
}
