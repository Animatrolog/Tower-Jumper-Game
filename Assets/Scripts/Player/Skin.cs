using UnityEngine;

public class Skin : MonoBehaviour
{
    public GameObject Model => gameObject;
    public Texture Icon => IconRenderer.Instance.RenderIcon(gameObject);
}
