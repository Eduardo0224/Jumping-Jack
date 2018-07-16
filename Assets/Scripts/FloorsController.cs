using System.Collections.Generic;
using UnityEngine;

public class FloorsController : Singleton<FloorsController>
{
    // Attributes
    #region Attributes
    [Header("Floors behaviour")]
    public List<Floor> floors;
    public RectTransform floorsParent;
    public RectTransform prefabHole;
    public GameObject prefabFloor;

    public const int FLOORS_NUMBER = 8;
    public int initialNumberHoles = 2;

    // Serves to verify direction of the next hole to create
    bool changeHoleDirection;
    [HideInInspector]
    // left limit of any floor - right limit of any floor
    public float leftConstraint, rightConstraint;
    #endregion

    // Properties
    #region Properties
    // Get negative or positive value based on the changeHoleDirection attribute
    public int GetHoleDirection { get { changeHoleDirection = !changeHoleDirection; return changeHoleDirection ? -1 : 1; } }
    // Get random number between 0 and amount of floors
    public int GetIndexRandomOfFloors => UnityEngine.Random.Range(0, floors.Count);
    #endregion

    // Event Functions
    #region Event Functions
    void Start()
    {
        // Creates floors
        GenerateFloors();
        // Create initial holes
        GenerateHoles(initialNumberHoles);
    }
    #endregion

    // Methods
    #region Methods
    /// <summary>
    /// Changes the parent floor.
    /// </summary>
    /// <param name="hole">Hole.</param>
    /// <param name="newParentIndex">Index.</param>
    public void ChangeParentFloor(Transform hole, int newParentIndex)
    {
        Floor newFloor = floors[ChangeIndexWithinRange(newParentIndex)];
        hole.transform.SetParent(newFloor.transform);
        hole.GetComponent<Hole>().ParentID = newFloor.GetID;
    }

    /// <summary>
    /// Changes the index within range.
    /// </summary>
    /// <returns>The index within range: 0 - floors.Count - 1.</returns>
    /// <param name="currentIndex">Current index.</param>
    public int ChangeIndexWithinRange (int currentIndex) {
        if (currentIndex >= floors.Count) return 0;
        if (currentIndex < 0) return floors.Count - 1;
        return currentIndex;
    }

    /// <summary>
    /// Generates the amount of floors based on the FLOORS_NUMBER attribute.
    /// </summary>
    void GenerateFloors()
    {
        for (int i = 0; i < FLOORS_NUMBER; i++)
        {
            Floor floor = Instantiate(prefabFloor, floorsParent).GetComponent<Floor>();
            // Changes the default name of Gameobject created
            floor.name = floor.name.Replace("(Clone)", "_" + (i + 1).ToString());
            floor.SetID(i);
            // Add floor to the Floors list
            floors.Add(floor);
        }
    }

    /// <summary>
    /// Generates the holes based on the value of the initialHoles parameter.
    /// </summary>
    /// <param name="initialHoles">number of initial holes.</param>
    void GenerateHoles(int initialHoles)
    {
        for (int i = 0; i < initialHoles; i++)
        {
            GenerateHoles();
        }
    }

    /// <summary>
    /// Generates one hole in one random floor.
    /// </summary>
    void GenerateHoles() => floors[GetIndexRandomOfFloors].CreateHole();
    #endregion
}
