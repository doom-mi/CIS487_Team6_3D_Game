using UnityEngine;
using UnityEngine.UIElements;

public class PlaceTower : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor;
    public Vector3 positionOffset;

    private GameObject tower;

    private Renderer rend;

    private void Start()
    {
        rend= GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
       if(tower!=null)
        {
            Debug.Log("Cant build here! - TODO: Display to user");
            return;
        }

       GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
       tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
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
