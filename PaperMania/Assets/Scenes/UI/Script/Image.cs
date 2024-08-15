using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InvertedMask : Image
{
    [SerializeField] private RectTransform maskArea;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        base.OnPopulateMesh(vh);

        if (maskArea == null)
            return;

        var vertices = new List<UIVertex>();
        vh.GetUIVertexStream(vertices);

        var rect = maskArea.rect;
        var corners = new Vector3[4];
        maskArea.GetWorldCorners(corners);

        for (int i = 0; i < vertices.Count; i++)
        {
            var vertex = vertices[i];
            var localPosition = transform.InverseTransformPoint(vertex.position);

            if (localPosition.x > corners[0].x && localPosition.x < corners[2].x &&
                localPosition.y > corners[0].y && localPosition.y < corners[2].y)
            {
                vertex.color = Color.clear;
            }

            vertices[i] = vertex;
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertices);
    }
}
