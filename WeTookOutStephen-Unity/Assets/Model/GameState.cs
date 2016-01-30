using System.Collections;

public class GameState {

    #region Properties

    /// <summary>
    /// Gets the singleton game state.
    /// </summary>
    public static GameState Instance
    {
        get
        {
            return _Instance ?? (_Instance = new GameState());
        }
    }

    #endregion

    #region Fields

    private static GameState _Instance;

    #endregion

    #region Constructors

    private GameState()
    {
    }

    #endregion
}
