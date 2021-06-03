using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MeshSettings : UpdatableData
{
    public const int numberSupportedLOD = 5;
    public const int numberSupportedChunkSizes = 9;
    public const int numberSupportedFlatShadedChunkSizes = 3;
    public static readonly int[] supportedChunkSizes = { 48, 72, 96, 120, 144, 168, 192, 216, 240 };

    public float meshScale = 2.5f;
    public bool useFlatShading;

    [Range(0, numberSupportedChunkSizes - 1)]
    public int chunkSizeIndex;

    [Range(0, numberSupportedFlatShadedChunkSizes - 1)]
    public int flatShadedChunkSizeIndex;

    //num verts per line for mesh LOD 0. Including the two extra verts that are excluded from final mesh used for normals
    public int numVertsPerLine
    {
        get
        {
            return supportedChunkSizes[useFlatShading ? flatShadedChunkSizeIndex: chunkSizeIndex] + 1;
        }
    }

    public float meshWorldSize
    {
        get
        {
            return (numVertsPerLine - 3) * meshScale;
        }
    }
}
