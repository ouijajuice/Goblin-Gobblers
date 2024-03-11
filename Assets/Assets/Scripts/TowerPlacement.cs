using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] towerPrefabs;
    public GameObject[] grayTowerPrefabs;
    private GameObject selectedTower;
    private GameObject selectedGrayTower;
    public float mousePosZ;
    private bool grayTowerIsActive;
    private GameObject instantiatedGrayTower;
    public string emptyPlotTag;
    public string fullPlotTag;
    public float circleCastRadius;
    public LayerMask plotLayer;
    public float distance;
    private Vector3 closestEmptyPlotPos;

    public Color color;
    public SpriteRenderer hammerSprite;

    public float placementCooldownDuration;
    private float placementCooldown;
    // Update is called once per frame
    void Update()
    {
        //Mouse position and getting selected tower
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mousePosZ;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D emptyPlotCollider = Physics2D.CircleCast(worldPos, circleCastRadius, transform.right, distance, plotLayer);
        if(emptyPlotCollider != null)
        {
            closestEmptyPlotPos = emptyPlotCollider.transform.position;
        }
        


        if (selectedTower == null)
        {
            grayTowerIsActive = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTower = towerPrefabs[0];
            selectedGrayTower = grayTowerPrefabs[0];
            grayTowerIsActive = true;
            instantiatedGrayTower = Instantiate(selectedGrayTower, worldPos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTower = towerPrefabs[1];
            selectedGrayTower = grayTowerPrefabs[1];
            grayTowerIsActive = true;
            instantiatedGrayTower = Instantiate(selectedGrayTower, worldPos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTower = towerPrefabs[2];
            selectedGrayTower = grayTowerPrefabs[2];
            grayTowerIsActive = true;
            instantiatedGrayTower = Instantiate(selectedGrayTower, worldPos, Quaternion.identity);
        }

        //On mouse click

        if (Input.GetMouseButtonDown(0) && placementCooldown <= 0)
        {
            worldPos.z = 0;
            if (emptyPlotCollider != null)
            {
                Instantiate(selectedTower, closestEmptyPlotPos, Quaternion.identity);
            }
            if(emptyPlotCollider == null)
            {
                Instantiate(selectedTower, worldPos, Quaternion.identity);
            }
            selectedTower = null;
            Destroy(instantiatedGrayTower);
            placementCooldown = placementCooldownDuration;
        }
        else
        {
            
            placementCooldown -= Time.deltaTime;
        }
        if (selectedTower != null && grayTowerIsActive == true)
        {
            if (emptyPlotCollider != null)
            {
                instantiatedGrayTower.transform.position = closestEmptyPlotPos;
            }
            else if (emptyPlotCollider == null)
            {
                instantiatedGrayTower.transform.position = worldPos;
            }
        }
        if (placementCooldown >= 0)
        {
            hammerSprite.color = color;
        }
        if (placementCooldown <= 0)
        {
            hammerSprite.color = Color.white;
        }

    }
}