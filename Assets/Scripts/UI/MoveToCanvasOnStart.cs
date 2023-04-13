using UnityEngine;

public class MoveToCanvasOnStart : MonoBehaviour
{
    private void Start()
    {
        transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
    }
}
