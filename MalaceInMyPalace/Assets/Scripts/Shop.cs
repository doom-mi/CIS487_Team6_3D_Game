using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    AudioManager audioManager;
    public Button arrowButton;
    public Button cannonButton;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public TowerBlueprint arrowTower;
    public TowerBlueprint cannonTower;

    private void Start()
    {
        buildManager = BuildManager.instance;
        arrowButton.interactable = true;
        cannonButton.interactable = true;
    }

    public void SelectArrowTower()
    {
        audioManager.PlaySFX(audioManager.selectTower);
        Debug.Log("Selected arrow tower");
        buildManager.SelectTowerToBuild(arrowTower);
        arrowButton.interactable = false;
        cannonButton.interactable = true;
    }
    public void SelectCannonTower()
    {
        audioManager.PlaySFX(audioManager.selectTower);
        Debug.Log("Selected cannon tower");
        buildManager.SelectTowerToBuild(cannonTower);
        cannonButton.interactable = false;
        arrowButton.interactable = true;
    }
}
