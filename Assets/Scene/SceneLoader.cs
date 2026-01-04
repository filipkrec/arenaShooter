using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public const int SCENE_MENU = 0;
    public const int SCENE_GAME = 1;

    public static void LoadScene(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }
}
