using UnityEngine;

public class LoadScene : MonoBehaviour
{
	public void LoadSceneCallback(string sceneName)
    {
        SceneLoader.Instance.LoadSceneAsync(sceneName);
    }
}
