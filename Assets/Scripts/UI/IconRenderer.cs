using UnityEngine;
using UnityEngine.UI;

public class IconRenderer : MonoBehaviour
{
    [SerializeField] private Camera _renderCamera;

    public static IconRenderer Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Texture RenderIcon(GameObject skinPrefab)
    {
        GameObject skinInstance = Instantiate(skinPrefab, transform);
        skinInstance.layer = 3;
        RenderTexture renderTexture = new RenderTexture(200, 200, 0);
        _renderCamera.targetTexture = renderTexture;
        _renderCamera.Render();
        skinInstance.SetActive(false);
        Destroy(skinInstance);
        return renderTexture;
    }
}
