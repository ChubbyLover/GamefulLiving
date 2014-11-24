using UnityEngine;
using System.Collections;

public class Level_Generation : MonoBehaviour {

	float fTileWidth;
	float fTileHeight;

	public int iHorizontalTiles=3;
	public int iVerticalTiles=3;

	Object[,] TilesSprites;

	GameObject Tile;
	GameObject Flow;
	GameObject Wallcollider;
 
	// Use this for initialization
	void Start () 
	{
		Time.timeScale=0;
		Object[] Buffer = ArrayConverter(); 
		TilesSprites = new Object[iVerticalTiles,iHorizontalTiles];
		int k=0;
		int iComensator=0;
		for(int i=0;i<Buffer.Length; i++)
		{			
			TilesSprites[k,i-iComensator] = new Object();
			TilesSprites[k,i-iComensator]=Buffer[i];
			if(i!=0&&(i+1)%iHorizontalTiles==0)
			{
				k++;
				iComensator+=iHorizontalTiles;
			}
		}
		Tile = Resources.Load("Prefabs/Objects/Level_Alpha/Tiles/Tile") as GameObject;
		Flow = Resources.Load("Prefabs/Objects/Level_Alpha/FlowMap") as GameObject;
		Wallcollider = Resources.Load("Prefabs/Objects/Level_Alpha/Wallcollider") as GameObject;
		//GameObject FlowClone = Instantiate(Flow,transform.position,transform.rotation) as GameObject;
		//GameObject Wallclone = Instantiate(Wallcollider,transform.position,transform.rotation) as GameObject	;

		fTileWidth = 19.2f;
		fTileHeight= 10.8f;

		// Placing tiles using a single array an helper variable for vertical shifting
		for(int i=0; i<iVerticalTiles; i++)
		{
			for(int j=0; j<iHorizontalTiles; j++)
			{
				GameObject TileClone = Instantiate(Tile,new Vector3(transform.position.x+j*fTileWidth,transform.position.y+i*fTileHeight,transform.position.z),transform.rotation) as GameObject;
				TileClone.name = "Tile"+j.ToString()+i.ToString();
				TileClone.GetComponent<Level_Tile>().iX=j;
				TileClone.GetComponent<Level_Tile>().iY=i;
				TileClone.GetComponent<SpriteRenderer>().sprite = TilesSprites[(iVerticalTiles-1)-i,j]as Sprite;
			}
		}
		Time.timeScale=1;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	Object[] ArrayConverter ()
	{
		Object[] Buffer;
		Buffer = Resources.LoadAll("Sprites/Objects/Level_Alpha/Tilesprites");
		Object[] Buffer2 = new Object[iVerticalTiles*iHorizontalTiles];
		int iUnevenNumbers =0;
		for (int i=0; i<Buffer.Length; i++)
		{
			if(i%2==1)
			{
				iUnevenNumbers++;
				Buffer2[i-iUnevenNumbers] = Buffer[i];
			}
		}
		return Buffer2;
	}
}
