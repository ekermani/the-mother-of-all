using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterMesh : MonoBehaviour {
	public Vector3[] newVertices;
//	public Vector2[] newUV;
	public int[] newTriangles;

	void Start() {
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = newVertices;
//		mesh.uv = newUV;
		mesh.triangles = newTriangles;
	}
}
// oriented horizontally
//The water GameObject should use the water Layer, 
// which you can set in the Inspector.