using UnityEngine;

public class Floor : MonoBehaviour
{
    // Attributes
    #region Attributes
    // ID of floor
    int id;
    #endregion

    // Properties
    #region Properties
    public int GetID => id;
    #endregion

    // Methods
    #region Methods
    /// <summary>
    /// Sets the floor identifier.
    /// </summary>
    /// <param name="id">Identifier.</param>
    public void SetID(int id) => this.id = id;

    /// <summary>
    /// Creates the hole inside this floor.
    /// </summary>
    public void CreateHole()
    {
        // Creates the hole and get Hole script component
        Hole hole = Instantiate(FloorsController.Instance.prefabHole.gameObject, transform).GetComponent<Hole>();
        // Establishes the negative or positive position
        hole.Direction = FloorsController.Instance.GetHoleDirection;
        // Establishes the initial position based on position on the outside of the floor multiplied by hole direction
        hole.transform.localPosition = FloorsGroup.Instance.GetPositionOutsideWidthFloor * hole.Direction;
        // Set hole parent ID
        hole.ParentID = id;
    }
    #endregion
}

