using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class EnableSortGroup : MonoBehaviour
{
    public SortingGroup SortingGroup;
    public float Delay = 2;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Delay);
        SortingGroup.enabled = true;
    }
}
