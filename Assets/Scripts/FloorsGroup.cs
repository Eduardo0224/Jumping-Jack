using UnityEngine;

public class FloorsGroup : Singleton<FloorsGroup> {

    // Properties
    #region Properties
    // Get limit value position outside width floor
    public float GetConstraintPosition => GetComponent<RectTransform>().rect.width / 2 + FloorsController.Instance.prefabHole.rect.width / 2;
    // Get limit position like Vector2
    public Vector2 GetPositionOutsideWidthFloor => new Vector2(GetConstraintPosition, 0);
    // Get half width of any floor
    public float GetFloorHalfWidth => GetComponent<RectTransform>().rect.width / 2;
    #endregion

    // Event Functions
    #region Event Functions
    void OnRectTransformDimensionsChange()
    {
        // Establishes the left limit used to location of the created hole
        FloorsController.Instance.leftConstraint = GetConstraintPosition * -1;
        // Establishes the right limit used to location of the created hole
        FloorsController.Instance.rightConstraint = GetConstraintPosition;
    }
    #endregion
}
