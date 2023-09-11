using UnityEngine;
using System.Linq;

public class IconRenderer : MonoBehaviour
{
    [SerializeField] private Camera _renderCamera;
    [SerializeField] private Texture2D _texture;

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
