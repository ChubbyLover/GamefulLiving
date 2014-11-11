using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PolygonCollections
{
	public class Converter_SVG  
	{
		protected List<Polygon> Polygons;
		// Directory of the File to read
		string sPath=@"";
		// Filename
		string sFilename="";
		// Contents of the File
		string sFileText;
		string sPointString="";
		string sSubstring="points=";

		List<int> iIndexlist;

		public Converter_SVG()
		{

		}
		List<Polygon> ConvertSVG()
		{
			return Polygons;
		}
		void readFile()
		{
			string text = System.IO.File.ReadAllText(sPath+sFilename);
		}
		void parseText()
		{
			for(int i=0; i<sFileText.Length; i++)
			{
				if(sFileText.IndexOf(sSubstring,i)>=i)
				{
					iIndexlist.Add(sFileText.IndexOf(sSubstring,i));
					i=sFileText.IndexOf(sSubstring,i);
				}
			}
		}
	}
}
