using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public int width, height;
    Grid placementGrid;

    // Start is called before the first frame update
    void Start()
    {
        placementGrid = new Grid(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
