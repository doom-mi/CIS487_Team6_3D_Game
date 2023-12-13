using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacematUI : MonoBehaviour
{
    public GameObject ui;

    public TMP_Text upgradeCost;
    public TMP_Text upgradeText;
    public Button upgradeButton;

    public TMP_Text sellAmount;

    private PlaceTower target;
    public void SetTarget(PlaceTower spot)
    {
        target = spot;
        transform.position = target.GetTilePosition();

        if (!spot.isUpgraded)
        {
            upgradeText.text = "Upgrade";
            upgradeText.fontStyle = FontStyles.Bold;
            upgradeCost.text = "$" + spot.towerBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeText.text = "Tower Upgraded";
            upgradeText.fontStyle = FontStyles.Bold;
            upgradeCost.text = "";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + spot.towerBlueprint.GetSellAmount();

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

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectPlacement();
    }
}
