using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor;

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

       //Build a turret
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
}
