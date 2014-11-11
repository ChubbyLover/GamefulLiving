using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PolygonCollections;

public class Converter_SVG : MonoBehaviour 
{
	protected List<Polygon> Polygons;
	protected List<Vector2> XYcoordinates;
	// Directory of the File to read
	string sPath=@"";
	// Filename
	string sFilename="";
	// Contents of the File
	string sFileText;
	string sPointString="";
	string sSubstring="points=";

	List<int> iIndexlist;

	void Start ()
	{
		iIndexlist = new List<int>();
		Polygons = new List<Polygon>();
		XYcoordinates = new List<Vector2>();
		readFile();
		parseText();
		Convert();
	}

	public Converter_SVG()
	{

	}
	List<Polygon> ConvertSVG()
	{
		return Polygons;
	}
	void readFile()
	{
	 sFileText = System.IO.File.ReadAllText(Application.dataPath + "/Resources/Sprites/Objects/Level_Prototype/SVG/SVG_Test.svg");
	}
	void parseText()
	{
		for(int i=0; i<sFileText.Length-sSubstring.Length; i++)
		{
			if(sFileText.IndexOf(sSubstring,i)>=i)
			{
				int iIndex =sFileText.IndexOf(sSubstring,i)+1;
				Debug.Log(iIndex);
				iIndexlist.Add(iIndex);
				i=sFileText.IndexOf(sSubstring,i);
			}
		}
	}
	void Convert()
	{
		Vector2 XY = new Vector2();
		int iSort=0;
		string sNumber="";

		foreach (int iIndex in iIndexlist)
		{
			for(int i=iIndex+sSubstring.Length; i<sFileText.Length; i++)
			{
				if(sFileText[i]!=','&&sFileText[i]!=' ')
				{
					sNumber+=sFileText[i];
					Debug.Log("Number:"+sFileText[i]);
				}
				if(sFileText[i]==',')
				{
					XY.x= float.Parse(sNumber);
					sNumber="";
					Debug.Log(",:"+sFileText[i]);
				}
				if(sFileText[i]==' ')
				{
					XY.y=float.Parse(sNumber);
					sNumber="";
					XYcoordinates.Add(XY);
					Debug.Log("Space:"+sFileText[i]);
				}
				if(sFileText[i]=='"')
				{
					Polygons.Add(new Polygon(XYcoordinates.ToArray()));
					Debug.Log("End Of Polygon:"+sFileText[i]);
					break;
				}
			}
			Debug.Log("ConvertDone");
			for(int i =0; i < Polygons[0].GetCoordinates().Length;i++)
			{
				Debug.Log(Polygons[0].GetCoordinates()[i].ToString());
			}
		}
	}
}

