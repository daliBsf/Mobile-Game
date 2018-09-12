using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StairController : MonoBehaviour {
	public GameObject tail;
	public Camera camera;
	private Vector2 position = new Vector2 (-0.605f,0f);
	public const float  TAIL_BASE_SPEED=5.5f;
	public static  int tailNumber=2;
	public GameObject start;
	public GameObject destroyedStair;
	private float lastTouch;
	private float lastBound = 2;
	public static int a=0;
	public static List<Color> listCouleur= new List<Color>();
	// Use this for initialization
	void Start () {
		lastBound = 2;
		position = new Vector2 (-0.605f,0f);
		tailNumber=2;
		InitialiseColor ();
		gameObject.transform.GetChild (0).gameObject.GetComponent<Renderer> ().material.color =listCouleur[a];
		a++;
		gameObject.transform.GetChild (1).gameObject.GetComponent<Renderer> ().material.color = listCouleur[a];
		a++;
		CreateTail ();
		// last touch 3maltha bch enna9es mel touch bech ma yjiouch barcha ta7t b3adhom melloul :p ; 
		lastTouch = Time.realtimeSinceStartup;
		
	
	}
	
	// Update is called once per frame
	void Update () {		
		if (Input.GetMouseButtonDown (0)&&!SphereController.endGame) {
			if (Time.realtimeSinceStartup - lastTouch > 0.5f ) {
				FixTail ();
				CreateTail ();
				lastTouch = Time.realtimeSinceStartup;	 
		}
	
	}
					}



	private void CreateTail( )
	{	
		GameObject o =(GameObject) Instantiate (tail, transform);
		tailNumber++;
		Move (o);
		Vector3 desiredPosition = new Vector3 (0f, (tailNumber - 1) * (-0.3f) - 0.005f, start.transform.position.z - 1f);
		Vector3 desiredScale = o.transform.localScale;
		desiredScale.z = lastBound;
		o.transform.localScale = desiredScale;
		o.transform.position = desiredPosition;
		o.GetComponent<Renderer> ().material.color = listCouleur[a];



	}
	private void Move(GameObject o)
	{ o.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, TAIL_BASE_SPEED+(SphereController.score/10)*0.7f);
	}
	private void FixTail()
	{   a = (a + 1) % listCouleur.Count;
		GameObject lastTail = transform.GetChild (transform.childCount - 1).gameObject;
		lastTail.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		lastTail.GetComponent<Rigidbody> ().isKinematic = true;
		lastTail.transform.localPosition += new Vector3 (0f, 0.005f, 0f);
		lastTail.tag = "fixed";
		if ((transform.childCount > 1)&&SphereController.score>2) {
			GameObject beforeLastTail = transform.GetChild (transform.childCount - 2).gameObject;
			Vector3 desiredScale = lastTail.transform.localScale;
			desiredScale.z = (lastTail.transform.localPosition.z - beforeLastTail.transform.localPosition.z);
			if((desiredScale.z<lastBound)&&(desiredScale.z>0))
			{
				lastTail.transform.localScale = desiredScale;
				Vector3 desiredPosition = lastTail.transform.localPosition;
				desiredPosition.z = beforeLastTail.transform.localPosition.z + (lastBound / 2f) + (desiredScale.z / 2f);
				lastTail.transform.localPosition = desiredPosition;
				float secondLastBound = lastBound;
				lastBound = desiredScale.z;
				GameObject o = (GameObject)Instantiate (destroyedStair);
				desiredPosition.z = desiredPosition.z - (desiredScale.z / 2);
				desiredScale.z = secondLastBound - desiredScale.z;
				desiredPosition.z-=desiredScale.z/2;
				desiredScale.z /= 2f;
				float x = desiredScale.z;
				desiredScale = o.transform.localScale;
				desiredScale.z = x;
				Debug.Log ("x:" + x);
				o.transform.localScale = desiredScale;
				o.transform.localPosition = desiredPosition;
				Color desiredColor =lastTail.GetComponent<Renderer> ().material.GetColor("_Color");

				for (int j = 0; j <5; j++) {
					for (int k = 0; k < 2; k++) {
						for (int l = 0; l < 5; l++) {
							o.transform.GetChild (j).GetChild (k).GetChild (l).gameObject.GetComponent<Renderer> ().material.color = desiredColor;

						}
					}
				}
			}
		}
		if (SphereController.score % 10 == 0 && lastBound<=1.9) 
			lastBound += 0.1f;

		

	} 
	private void InitialiseColor()
	{
		Debug.Log ("color init");
		Color myColor;
		ColorUtility.TryParseHtmlString("#FFCDD2",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#EF9A9A",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E57373",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#EF5350",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F44336",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E53935",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#D32F2F",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#C62828",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#B71C1C",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#880E4F",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#AD1457",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#C2185B",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#D81B60",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E91E63",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#EC407A",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F06292",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F48FB1",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F8BBD0",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FCE4EC",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F3E5F5",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E1BEE7",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#CE93D8",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#BA68C8",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#AB47BC",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#9C27B0",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#8E24AA",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#7B1FA2",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#6A1B9A",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#4A148C",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#311B92",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#4527A0",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#512DA8",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#5E35B1",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#673AB7",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#7E57C2",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#9575CD",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#B39DDB",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#D1C4E9",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#EDE7F6",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#C5CAE9",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#9FA8DA",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#7986CB",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#5C6BC0",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#3F51B5",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#3949AB",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#303F9F",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#283593",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#1A237E",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#0D47A1",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#1565C0",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#1976D2",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#1E88E5",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#1E88E5",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#42A5F5",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#64B5F6",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#90CAF9",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#BBDEFB",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E3F2FD",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E1F5FE",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#B3E5FC",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#81D4FA",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#4FC3F7",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#29B6F6",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#03A9F4",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#039BE5",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#0288D1",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#0277BD",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#01579B",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#006064",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#00838F",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#0097A7",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#00ACC1",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#00BCD4",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#26C6DA",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#4DD0E1",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#80DEEA",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#B2EBF2",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E0F7FA",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E0F2F1",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#B2DFDB",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#80CBC4",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#4DB6AC",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#26A69A",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#009688",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#00897B",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#00796B",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#00695C",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#004D40",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#1B5E20",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#2E7D32",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#388E3C",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#43A047",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#4CAF50",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#66BB6A",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#81C784",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#A5D6A7",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#C8E6C9",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E8F5E9",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F1F8E9",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#DCEDC8",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#C5E1A5",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#AED581",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#9CCC65",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#8BC34A",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#7CB342",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#689F38",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#558B2F",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#33691E",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#827717",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#9E9D24",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#AFB42B",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#C0CA33",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#CDDC39",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#D4E157",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#DCE775",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E6EE9C",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F0F4C3",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFF9C4",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFF59D",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFF176",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFEE58",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFEB3B",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FDD835",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FBC02D",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F9A825",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F57F17",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FF6F00",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FF8F00",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFA000",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFB300",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFC107",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFCA28",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFD54F",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFE082",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFECB3",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFE0B2",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFCC80",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFB74D",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFA726",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FF9800",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FB8C00",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F57C00",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#EF6C00",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E65100",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#BF360C",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#D84315",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E64A19",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#F4511E",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FF5722",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FF7043",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FF8A65",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFAB91",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#FFCCBC",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#D7CCC8",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#BCAAA4",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#A1887F",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#8D6E63",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#795548",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#6D4C41",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#5D4037",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#4E342E",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#424242",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#616161",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#757575",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#9E9E9E",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#BDBDBD",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#E0E0E0",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#CFD8DC",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#B0BEC5",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#90A4AE",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#607D8B",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#546E7A",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#455A64",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#37474F",out myColor);
		listCouleur.Add (myColor);
		ColorUtility.TryParseHtmlString("#263238",out myColor);
		listCouleur.Add (myColor);

















	}


}
