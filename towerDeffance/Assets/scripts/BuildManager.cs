using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TowerSelector towerSelector;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && towerSelector.GetSelectedTower() != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0);
            
            //if (hit.collider != null)
            //{
                Instantiate(towerSelector.GetSelectedTower(), mousePos, Quaternion.identity);
            //}

            towerSelector.SetNullTower();
        }
    }
}
