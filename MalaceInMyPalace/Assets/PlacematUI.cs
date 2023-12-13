using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacematUI : MonoBehaviour
{
    public GameObject ui;

    private PlaceTower target;
    public void SetTarget(PlaceTower spot)
    {
        target = spot;
        transform.position = target.GetTilePosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
