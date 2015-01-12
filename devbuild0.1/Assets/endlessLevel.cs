using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class endlessLevel : MonoBehaviour {

	public GameObject[] infections;
	public Vector3[] spawnPoints;
	public GameObject notification;
	public int stage;
	public int spawnings;
	public Text infooutput;
	
	// Use this for initialization
	void Start () {
		stage = 0;
		spawnPoints = new Vector3[19];
		int i = 0;
		foreach (Transform child in transform)
		{
			spawnPoints[i] = child.position;
			i++;
		}
		infections = new GameObject[4];
		infections[0] = (GameObject) Resources.Load("Prefabs/Objects/Enemy/Alpha/Scharlach");
		infections[1] = (GameObject) Resources.Load("Prefabs/Objects/Enemy/Alpha/Diphterie");
		infections[2] = (GameObject) Resources.Load("Prefabs/Objects/Enemy/Alpha/Keuchusten");
		infections[3] = (GameObject) Resources.Load("Prefabs/Objects/Enemy/Alpha/Tetanus");
		notification = (GameObject) Resources.Load("Prefabs/GUI/Alpha_Menu/alert");
		InvokeRepeating("CheckForPathogens", 1f, 2f); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Spawn () {
		// create new shit
		int spawnPointIndex = Random.Range(0,19);
		GameObject newPathogen = (GameObject) Instantiate(infections[Random.Range(0,4)], spawnPoints[spawnPointIndex], gameObject.transform.rotation);
		GameObject newNotification = (GameObject) Instantiate(notification, spawnPoints[spawnPointIndex], gameObject.transform.rotation);
		Destroy (newNotification, 5);
		Pathogen_Behaviour newPathogenBehaviour = newPathogen.GetComponent<Pathogen_Behaviour>();
		// make shit spread according to stage
		newPathogenBehaviour.MytosisMin = (int) (400.0f/((float)stage+1.0f));
		newPathogenBehaviour.MytosisMax = (int) (20.0f + (3800.0f / ((float)stage + 9.0f)));
		newPathogenBehaviour.maxAmountOfPathogens = (stage+3)*3;
		newPathogenBehaviour.bEasymode = true;
		// maybe create even more shit later
		spawnings--;
		if(spawnings>0) Invoke("Spawn", Random.Range(1,20));
	}
	
	void CheckForPathogens()	
	{
		GameObject[] Pathogens = GameObject.FindGameObjectsWithTag("Pathogen") as GameObject[];
		GameObject[] PathogensMarked = GameObject.FindGameObjectsWithTag("Marked") as GameObject[];
		if(Pathogens.Length==0&&PathogensMarked.Length==0)
		{
			stage++;
			spawnings = Mathf.RoundToInt(Mathf.Sqrt(stage));
			infooutput.text = "Level " + stage + ". Spawning " + spawnings + " Infections. Multiplying at a rate between " + (int) (400.0f/((float)stage+1.0f)) + " and " + (int) (20.0f + (3800.0f / ((float)stage + 9.0f))) + " frames and a total maximum of " + (stage+3)*3 + " pathogens.";
			CancelInvoke("Spawn");
			Pathogen_Behaviour.stopSpreading=false;
			Pathogen_Behaviour.amountOfPathogens=0;
			Spawn ();
			// Invoke("Spawn", 2);
		}
	}
}
