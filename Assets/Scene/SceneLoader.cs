using UnityEngine.AddressableAssets;

public static class SceneLoader
{
    public const string SCENE_MENU = "MainMenuScene";
    public const string SCENE_GAME = "GameScene";

    public static void LoadScene(string _scene)
    {
        Addressables.LoadSceneAsync(_scene);
    }
}
