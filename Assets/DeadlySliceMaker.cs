using UnityEngine;

public class DeadlySliceMaker : MonoBehaviour
{
    [SerializeField] private Material _deadlyMaterial;
    [SerializeField] private string _deadlyTag = "Deadly";

    public void MakeDeadlySlices(float deadlyrobability = 0, int minimumSafeSlices = 1)
    {
        int deadlySliceCounter = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (deadlySliceCounter >= transform.childCount - minimumSafeSlices) break;

            float roll = Random.Range(0.0f, 1.0f);

            if (roll <= deadlyrobability)
            {
                MakeSlieceDeadly(transform.GetChild(i));
                deadlySliceCounter ++;
            }
        }
    }

    private void MakeSlieceDeadly(Transform slice)
    {
        slice.GetComponent<Renderer>().material = _deadlyMaterial;
        slice.tag = _deadlyTag;
    }
}
