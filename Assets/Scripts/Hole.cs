using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hole : MonoBehaviour {

    // Attributes
    #region Attributes
    // direction - parentID
    int direction, parentID;
    #endregion

    // Properties
    #region Properties
    public int ParentID { get { return parentID; } set { parentID = value; } }
    public int Direction { get { return direction; } set { direction = value; } }
    #endregion

    // Event Functions
    #region Event Functions
    void LateUpdate()
    {
        // if the position of hole is major of left constraint
        if (transform.localPosition.x < FloorsController.Instance.leftConstraint)
        {
            // this hole changes of current floor (in the game view goes up one floor)
            FloorsController.Instance.ChangeParentFloor(transform, --ParentID);
            // appear in the opposite side from where disappeared 
            transform.localPosition = new Vector2(FloorsController.Instance.rightConstraint, 0);
        }
        // if the position of hole is major of right constraint
        else if (transform.localPosition.x > FloorsController.Instance.rightConstraint)
        {
            // this hole changes of current floor (in the game view goes down one floor)
            FloorsController.Instance.ChangeParentFloor(transform, ++parentID);
            // appear in the opposite side from where disappeared
            transform.localPosition = new Vector2(FloorsController.Instance.leftConstraint, 0);
        }
        else
        {
            // this hole is moved based in the direction, with a constant speed
            transform.Translate(new Vector2(FloorsGroup.Instance.GetFloorHalfWidth * direction, 0) * Time.deltaTime * 0.6f);
        }
    }   
    #endregion
}
