using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;
/// <summary>
/// This just sends and receives some tracker data to test
/// </summary>
public class UnityVRPNTest : MonoBehaviour {

	public Slider slider;
	public Text text;
	public float[] data = new float[1];
	public string serverName;
	public int serverPort;
	public string clientFullAddress;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		UnityVRPN.getAnalogInfo (clientFullAddress,1,data);
		UnityVRPN.sendAnalogInfo (serverName, serverPort, 1, new float[]{slider.value});
		text.text = ""+data [0];

	}
}
