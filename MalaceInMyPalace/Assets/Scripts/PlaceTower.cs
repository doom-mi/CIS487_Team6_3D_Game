using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceTower : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;

    BuildManager buildManager;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        rend= GetComponent<Renderer>();
        buildManager = BuildManager.instance;
    }

    public Vector3 GetTilePosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (tower!=null)
        {
            buildManager.SelectPlacemat(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            Debug.Log("Tower is NULL mouse down");
            return;
        }

        BuildTower(buildManager.GetTowerToBuild());
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        audioManager.PlaySFX(audioManager.playerPlaceTower);

        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that! TODO: DISPLAY TO USER");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _tower = Instantiate(blueprint.prefab, GetTilePosition(), Quaternion.identity);
        tower = _tower;

        towerBlueprint = blueprint;

        Debug.Log("Tower built! Money left: " + PlayerStats.Money);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        foreach (Material mat in rend.materials)
        {
            mat.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        foreach (Material mat in rend.materials)
        {
            mat.color = defaultColor;
        }
    }

    public void UpgradeTower()
    {
        audioManager.PlaySFX(audioManager.playerPlaceTower);

        if (PlayerStats.Money < towerBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that! TODO: DISPLAY TO USER");
            return;
        }

        PlayerStats.Money -= towerBlueprint.upgradeCost;

        Destroy(tower);
        GameObject _tower = Instantiate(towerBlueprint.upgradedPrefab, GetTilePosition(), Quaternion.identity);
        tower = _tower;

        isUpgraded = true;

        Debug.Log("Tower upgraded! Money left: " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += towerBlueprint.GetSellAmount();
        Destroy(tower);
        towerBlueprint = null;
    }
}
