using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceTower : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor;
    public Vector3 positionOffset;

    [Header("OPTIONAL")]
    public GameObject tower;

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

        if (!buildManager.CanBuild)
        {
            Debug.Log("Tower is NULL mouse down");
            return;
        }

        if (tower!=null)
        {
            Debug.Log("Cant build here! - TODO: Display to user");
            return;
        }

       GameObject towerToBuild = buildManager.GetTowerToBuild();
       audioManager.PlaySFX(audioManager.playerPlaceTower);
       tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
        buildManager.BuildTowerOn(this);
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
}
