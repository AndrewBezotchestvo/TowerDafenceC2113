using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGhost : MonoBehaviour
{
    private GameObject currentGhost;
    public TowerSelector selector;

    void Update()
    {
        if (selector.GetSelectedTower() != null)
        {
            if (currentGhost == null)
            {
                currentGhost = Instantiate(selector.GetSelectedGhostTower());
            }

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentGhost.transform.position = mousePos;
        }
        else if (currentGhost != null)
        {
            Destroy(currentGhost);
        }
    }
}
