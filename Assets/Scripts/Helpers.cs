using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Helper class with generic actions
/// </summary>
public static class Helpers {

    /// <summary>
    /// Coroutine used to perform any action in given duration 
    /// </summary>
    /// <param name="actionToPerform">Action to perform.</param>
    /// <param name="duration">Duration (special to make interpolations).</param>
    static IEnumerator IEPerfomAction(Action<float> actionToPerform = null, float duration = 0.5f)
    {
        float timeRemaining = 0;
        while (timeRemaining <= duration)
        {
            timeRemaining = timeRemaining + Time.deltaTime;
            float percent = Mathf.Clamp01(timeRemaining / duration);
            actionToPerform?.Invoke(percent);
            yield return null;
        }
    }

    /// <summary>
    /// Performs the action in given duration.
    /// </summary>
    /// <param name="instace">Instace of monobehaviour.</param>
    /// <param name="actionToPerform">Action to perform.</param>
    /// <param name="duration">Duration (special to make interpolations).</param>
    public static void PerfomAction(MonoBehaviour instace, Action<float> actionToPerform = null, float duration = 0.5f) => instace.StartCoroutine(IEPerfomAction(actionToPerform, duration));
}