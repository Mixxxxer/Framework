using UnityEngine;

public class GameReadyPanelController : MonoBehaviour 
{
    
    #region Caching

    /// <summary>
    /// Cached copy of the current transform
    /// </summary>
    private Transform thisTransform;

    public new Transform transform
    {
        get
        {
            return thisTransform ?? (thisTransform = base.transform);
        }
    }

    #endregion

    #region Public Variables
    #endregion

    #region Private Variables
    #endregion

    #region Initialise 

    public void Awake()
    {
    }

    public void Start () 
    {
	}

    #endregion

    #region Enable / Disable

    public void OnEnable()
    {
    }

    public void OnDisable()
    {
    }

    #endregion

    #region Buttons

    public void OnLevelsClick()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("OnLevelsClick");
        }
    }

    public void OnRateUsClicked()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("OnRateUsClicked");
        }
    }

    public void OnSoundClicked()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("OnSoundClicked");
        }
    }

    public void OnLeaderBoardClicked()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("OnLeaderBoardClicked");
        }
    }

    #endregion
}
