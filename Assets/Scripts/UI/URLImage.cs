using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class URLImage : MonoBehaviour
{
    private RawImage _rawImage;

    private void Awake()
    {
        _rawImage= GetComponent<RawImage>();
    }

    public void SetImageFromURL(string imageURL)
    {
        StartCoroutine(DownloadImageCoroutine(imageURL));
    }

    private IEnumerator DownloadImageCoroutine(string imageURL)
    {
        if (string.IsNullOrEmpty(imageURL)) yield return null;

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageURL);
        request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        if (string.IsNullOrEmpty(request.error))
            _rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        else
            Debug.Log(request.error);
    }
}
