using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinIconPoser : MonoBehaviour
{
    public Vector2 CalculateMargins(Texture texture)
    {
        Texture2D mTexture = texture as Texture2D;
        Color[] c = mTexture.GetPixels(0, 0, 200, 200);

        int up = 0;
        int down = 0;

        for (int i = 39999; i >= 0; i--)
        {
            if (c[i].a != 0f)
            {
                down = i / 200;
                break;
            }
        }

        for (int i = 0; i < 40000; i++)
        {
            if (c[i].a != 0f)
            {
                up = i / 200;
                break;
            }
        }

        return new Vector2(up,down);
    }
}
