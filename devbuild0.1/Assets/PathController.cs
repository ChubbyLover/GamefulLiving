using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathController : MonoBehaviour {
	
	public List<Vector2> BloodPath = new List<Vector2>();
	MeshFilter meshFilter;
	MeshRenderer meshRenderer; 
	LineRenderer lineRenderer;
	
	
	void Start () {
		meshFilter = GetComponent<MeshFilter>();
		meshRenderer = GetComponent<MeshRenderer>();
		lineRenderer = GetComponent<LineRenderer>();
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			BloodPath.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		
		if (Input.GetKeyDown("space"))
		{	
			BloodPath.Add(BloodPath[0]);
			Vector2 InwardsVector = (BloodPath[1]-BloodPath[BloodPath.Count-1]).normalized + (BloodPath[BloodPath.Count-2]-BloodPath[BloodPath.Count-1]).normalized;
			
			
			if(Vector3.Cross((BloodPath[1]-BloodPath[BloodPath.Count-1]),(BloodPath[BloodPath.Count-2]-BloodPath[BloodPath.Count-1])).z < 0)
				BloodPath.Add(BloodPath[BloodPath.Count-1]-InwardsVector.normalized*2.0f);
			else 
				BloodPath.Add(BloodPath[BloodPath.Count-1]+InwardsVector.normalized*2.0f);
				
				
			int closeCircleIndex = BloodPath.Count-1;
			
			int i = BloodPath.Count-3;
			while(i>0)
			{
				Vector2 InwardsVector2 = (BloodPath[i+1]-BloodPath[i]).normalized + (BloodPath[i-1]-BloodPath[i]).normalized;
				float thickness = 1.0f+(180-Vector2.Angle((BloodPath[i+1]-BloodPath[i]),(BloodPath[i-1]-BloodPath[i])))/80.0f;
				if(Vector3.Cross((BloodPath[i+1]-BloodPath[i]),(BloodPath[i-1]-BloodPath[i])).z < 0)
					BloodPath.Add(BloodPath[i]-InwardsVector2.normalized*thickness);
				else 
					BloodPath.Add(BloodPath[i]+InwardsVector2.normalized*thickness);
				
				i--; 
			}
			BloodPath.Add(BloodPath[closeCircleIndex]);
			// BloodPath.Add(BloodPath[0]+Vector2.up*0.2f);
			CreateMesh();
			BloodPath.Clear();
		}
	}
	
	void CreateMesh()
	{
		Vector3[] vertices = new Vector3[BloodPath.Count];
		Vector3[] normals = new Vector3[BloodPath.Count];
		Vector2[] uvCords = new Vector2[BloodPath.Count];
		//Triangulator tr = new Triangulator(BloodPath.ToArray());
		int[] triangles = Triangulate();
		// System.Array.Reverse(triangles);
		
		int i = 0;
		while(i<BloodPath.Count)
		{
			vertices[i] = new Vector3(BloodPath[i].x,BloodPath[i].y,0);
			if(i>0) Debug.DrawLine(vertices[i],vertices[i-1], Color.cyan, 100.0f);
			i++; 
		}
		i=0;
		while(i<BloodPath.Count)
		{
			normals[i] = Vector3.forward;
			i++; 
		}
		i=0;
		while(i<BloodPath.Count)
		{
			if(i<BloodPath.Count/2) 
			{
				if(i%2==0) uvCords[i] = new Vector2(0,0);
				else uvCords[i] = new Vector2(1,0);
			}
			else 
			{
				if(i%2==0) uvCords[i] = new Vector2(1,1);
				else uvCords[i] = new Vector2(0,1);
			}
			i++; 
		}
		
		
		
		/*Vector3[] vertices = new Vector3[BloodPath.Count];
		Vector3[] normals = new Vector3[BloodPath.Count];
		int[] triangles = new int[BloodPath.Count*3];
		int i = 0;
		while(i<BloodPath.Count)
		{
			vertices[i] = new Vector3(BloodPath[i].x,BloodPath[i].y,0);
			if(i>0)Debug.DrawLine(vertices[i-1], vertices[i],Color.red,10.0f);
			i++; 
		}
		while(i<BloodPath.Count)
		{
			normals[i] = Vector3.back;
			i++; 
		}
		while(i<BloodPath.Count)
		{
			triangles[i*3] = i;
			triangles[i*3+1] = i+1;
			triangles[i*3+2] = i+2;
			i++;
		}
		
		*/
		
		Mesh newMesh =  new Mesh();
		newMesh.vertices = vertices;
		newMesh.triangles = triangles;
		newMesh.normals = normals;
		newMesh.uv = uvCords;
		
		meshFilter.mesh = newMesh; 
	}
	
	int[] Triangulate() 
	{
		List<int> triangles = new List<int>();
		int i=0;
		
		while(i<BloodPath.Count/2)
		{
			int a = i;
			int b = i+1;
			int c = BloodPath.Count-i-2;
			int d = BloodPath.Count-i-1;
			triangles.Add(a);
			triangles.Add(b);
			triangles.Add(d);
			triangles.Add(b);
			triangles.Add(c);
			triangles.Add(d);
			i++;
		}
		return triangles.ToArray();
	}
}
