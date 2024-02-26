using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] towerPrefabs;
    private GameObject selectedTower;
    public float mousePosZ;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTower = towerPrefabs[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTower = towerPrefabs[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTower = towerPrefabs[2];
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mousePosZ;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            Instantiate(selectedTower, worldPos, Quaternion.identity);
        }
    }
}
