using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceTower : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor;
    public Vector3 positionOffset;

    private GameObject tower;

    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend= GetComponent<Renderer>();
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTowerToBuild() == null)
        {
            Debug.Log("Tower is NULL mouse down");
        }

        if (tower!=null)
        {
            Debug.Log("Cant build here! - TODO: Display to user");
            return;
        }

       GameObject towerToBuild = buildManager.GetTowerToBuild();
       tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTowerToBuild() == null)
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
