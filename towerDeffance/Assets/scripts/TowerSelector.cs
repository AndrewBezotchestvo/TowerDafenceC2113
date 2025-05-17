using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public GameObject[] towerPrefabs; // ������� ���� �����
    private GameObject selectedTower; // ��������� �����

    public void SelectTower(int towerIndex)
    {
        selectedTower = towerPrefabs[towerIndex];
    }

    public GameObject GetSelectedTower()
    {
        return selectedTower;
    }
}
