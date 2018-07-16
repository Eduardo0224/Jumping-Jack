using UnityEngine;

/// <summary>
/// Design Pattern: Singleton
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Attributes
    #region Attributes
    private static T instance;
    #endregion

    // Properties
    #region Properties
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
        #endregion
    }
}