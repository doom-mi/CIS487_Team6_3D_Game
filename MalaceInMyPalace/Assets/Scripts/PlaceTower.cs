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

        audioManager.PlaySFX(audioManager.playerPlaceTower);
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
