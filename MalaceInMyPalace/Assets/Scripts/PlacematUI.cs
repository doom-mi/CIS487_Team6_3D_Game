using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacematUI : MonoBehaviour
{
    public GameObject ui;

    public TMP_Text upgradeCost;
    public TMP_Text upgradeText;
    public Button upgradeButton;

    private PlaceTower target;
    public void SetTarget(PlaceTower spot)
    {
        target = spot;
        transform.position = target.GetTilePosition();

        if (!spot.isUpgraded)
        {
            upgradeCost.text = "$" + spot.towerBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeText.text = "Tower upgraded";
            upgradeText.fontStyle = FontStyles.Bold;
            upgradeCost.text = "";
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectPlacement();
    }
}
