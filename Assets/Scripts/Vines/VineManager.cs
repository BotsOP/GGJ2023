using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VineManager : MonoBehaviour
{
    public MeshFilter meshFilter;
    public ComputeShader computeShader;
    public int roundSegments;
    public float vineSize;
    public List<Transform> transforms;
    public Material vineGrowMaterial;

    private Mesh vines;
    private int kernelID;
    private int cachedVineSegmets;
    private int threadGroupSize;

    private GraphicsBuffer gpuVertices;
    private GraphicsBuffer gpuIndice;
    private ComputeBuffer pathPoints;
    private int vineSegments => transforms.Count - 1;
    private int totalVerts => roundSegments * vineSegments + roundSegments;
    private int totalIndice => totalVerts * 6 - (roundSegments * 6);

    private void OnEnable()
    {
        pathPoints = new ComputeBuffer(transforms.Count, sizeof(float) * 16, ComputeBufferType.Structured);
        CreateMesh();
    }

    private void OnDisable()
    {
        gpuVertices?.Dispose();
        gpuVertices = null;
        gpuIndice?.Dispose();
        gpuIndice = null;
        pathPoints?.Dispose();
        pathPoints = null;
    }

    private void CreateMesh()
    {
        vines = new Mesh();
        vines.name = "vines";
        
        vines.indexFormat = IndexFormat.UInt32;
		
        vines.vertexBufferTarget |= GraphicsBuffer.Target.Structured;
        vines.indexBufferTarget |= GraphicsBuffer.Target.Structured;

        Vector3[] verts = new Vector3[totalVerts];
        int[] indices = new int[totalIndice];
        Vector2[] uv = new Vector2[totalVerts];

        vines.vertices = verts;
        vines.triangles = indices;
        vines.uv = uv;

        vines.subMeshCount = 1;

        vines.bounds = new Bounds(Vector3.zero, new Vector3(500, 500, 500));

        meshFilter.sharedMesh = vines;
        
        vines.SetVertexBufferParams(vines.vertexCount, 
            new VertexAttributeDescriptor(VertexAttribute.Position, stream: 0, dimension: 3), 
            new VertexAttributeDescriptor(VertexAttribute.Normal, stream: 0, dimension: 3),
            new VertexAttributeDescriptor(VertexAttribute.Tangent, stream: 0, dimension: 4), 
            new VertexAttributeDescriptor(VertexAttribute.TexCoord0, stream: 0, dimension: 2)
        );
    }

    private void UpdateMesh()
    {
        Vector3[] verts = new Vector3[totalVerts];
        int[] indices = new int[totalIndice];
        Vector2[] uv = new Vector2[totalVerts];

        vines.vertices = verts;
        vines.triangles = indices;
        vines.uv = uv;
        
        vines.SetVertexBufferParams(vines.vertexCount, 
            new VertexAttributeDescriptor(VertexAttribute.Position, stream: 0, dimension: 3), 
            new VertexAttributeDescriptor(VertexAttribute.Normal, stream: 0, dimension: 3),
            new VertexAttributeDescriptor(VertexAttribute.Tangent, stream: 0, dimension: 4), 
            new VertexAttributeDescriptor(VertexAttribute.TexCoord0, stream: 0, dimension: 2)
        );
        
        vines.indexFormat = IndexFormat.UInt32;
		
        vines.vertexBufferTarget |= GraphicsBuffer.Target.Structured;
        vines.indexBufferTarget |= GraphicsBuffer.Target.Structured;
        
        pathPoints?.Dispose();
        pathPoints = null;
        pathPoints = new ComputeBuffer(transforms.Count, sizeof(float) * 16, ComputeBufferType.Structured);
    }

    private void CalculateVertexPositions()
    {
        kernelID = computeShader.FindKernel("CalculateVertex");
        computeShader.GetKernelThreadGroupSizes(kernelID, out uint threadGroupSizeX, out _, out _);
        threadGroupSize = Mathf.CeilToInt((float)totalVerts / threadGroupSizeX);

        pathPoints.SetData(CreateMatrixArray(transforms.ToArray()));
        
        computeShader.SetInt("roundSegments", roundSegments);
        computeShader.SetInt("vineSegments", vineSegments);
        computeShader.SetInt("totalVerts", totalVerts);
        computeShader.SetFloat("vineSize", vineSize);
        
        computeShader.SetBuffer(kernelID,"gpuVertices", gpuVertices);
        computeShader.SetBuffer(kernelID, "pathPoints", pathPoints);

        computeShader.Dispatch(kernelID, threadGroupSize, 1, 1);
        
        vertex[] verts = new vertex[totalVerts];
        vines.GetVertexBuffer(0).GetData(verts);
        //Debug.Log(verts);
    }

    private void CalculateIndices()
    {
        kernelID = computeShader.FindKernel("CalculateIndex");
        computeShader.GetKernelThreadGroupSizes(kernelID, out uint threadGroupSizeX, out _, out _);
        threadGroupSize = Mathf.CeilToInt((float)totalIndice / 6 / threadGroupSizeX);

        computeShader.SetInt("totalIndice", totalIndice);
        computeShader.SetBuffer(kernelID,"gpuIndice", gpuIndice);

        computeShader.Dispatch(kernelID, threadGroupSize, 1, 1);

        int[] indices = new int[totalIndice];
        gpuIndice.GetData(indices);
        //Debug.Log(indices);
    }

    void Update()
    {
        if (Time.time > 1)
        {
            if (cachedVineSegmets < vineSegments)
            {
                UpdateMesh();
            }
            gpuVertices?.Dispose();
            gpuVertices = null;
            gpuVertices = vines.GetVertexBuffer(0);
            gpuIndice?.Dispose();
            gpuIndice = null;
            gpuIndice = vines.GetIndexBuffer();
            vineGrowMaterial.SetFloat("_VineSegments", vineSegments);
            CalculateVertexPositions();
            CalculateIndices();
            cachedVineSegmets = vineSegments;
        }
        
    }

    private void StartNewMesh()
    {
        
    }
    
    private Matrix4x4[] CreateMatrixArray(Transform[] transforms)
    {
        Matrix4x4[] matrices = new Matrix4x4[transforms.Length];
        for (int i = 0; i < transforms.Length; i++)
        {
            Quaternion rotation = transforms[i].rotation;
            Vector3 pos = transforms[i].position;
            matrices[i] = new Matrix4x4(
                rotation * new Vector4(1, 0, 0, 0),
                rotation * new Vector4(0, 1, 0, 0),
                rotation * new Vector4(0, 0, 1, 0),
                new Vector4(pos.x, pos.y, pos.z , 1)
            );
        }
        return matrices;
    }
    
    
}

struct vertex
{
    Vector3 position;
    Vector3 normal;
    Vector4 tangent;
    private Vector2 uv;
};
