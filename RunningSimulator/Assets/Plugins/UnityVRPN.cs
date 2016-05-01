using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Runtime.InteropServices;



public class UnityVRPN {
	

#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void getButtonData(string name, int num_buttons, int[] data, out long timestamp);
	
#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void getTrackerData(string name, int sensor,  double[] pos, double[] quat, out long timestamp);
				
#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void getAnalogData(string name, int num_channels, double[] data, out long timestamp);
	
#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void getTextData(string name, StringBuilder text, out long timestamp);
#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void setAnalogOutput(string name, int num_channels, double[] data);
		
#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void sendTextData(string name, int port, string text);
		
#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void sendAnalogData(string name, int port, int num, double[] data);
		
#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void sendButtonData(string name, int port, int num, int[] data);
		
#if UNITY_IPHONE
	[DllImport ("__Internal")]
#else
	[DllImport ("UnityVRPN")]
#endif
private static extern void sendTrackerData(string name, int port, int sensor, double[] pos, double[] quat);
	

	
	//class function
	public static void getButtonInfo(string name, int num_buttons, int[] data){
		
			long timestamp = 0;
			getButtonData(name,num_buttons,data,out timestamp);

	}

	public static void getTrackerInfo(string name, int sensor, ref Vector3 pos, ref Quaternion quat){
		float[] p = new float[3];
		float[] q = new float[4];
		getTrackerInfo(name,sensor,p,q);
		pos.Set (p[0],p[1],p[2]);
		quat.Set (q[0],q[1],q[2],q[3]);
	}
	public static void getTrackerInfo(string name, int sensor, float[] pos, float[] quat){
		double[] posD = new double[pos.Length];
		double[] quatD = new double[quat.Length];

			long timestamp = 0;
			getTrackerData(name,sensor,posD,quatD,out timestamp);

		for(int i=0;i<3;i++){
			pos[i] = (float)posD[i];
			quat[i] = (float)quatD[i];
		}
		quat[3] = (float)quatD[3];
	}
	public static void getAnalogInfo(string name, int num_channels, float[] data){
		double[] dataD = new double[data.Length];

			long timestamp = 0;
			getAnalogData(name, num_channels,dataD, out timestamp);

		for(int i=0;i<data.Length;i++){
			data[i] = (float)dataD[i];
		}
	}

	
	public static  void getTextInfo(string name, StringBuilder text){
		
			long timestamp = 0;
			getTextData(name,text,out timestamp);

	}
	
	public static  void sendAnalogOutput(string name, int num, float[] outputs){

		double[] temp = new double[num];
		for(int i=0;i<num;i++){
			temp[i] = (double)outputs[i];
		}


			setAnalogOutput(name,num,temp);

	}
	
	public static  void sendTextInfo(string name, int port, string text){
		
			sendTextData(name,port,text);

	}

	public static  void sendAnalogInfo(string name, int port, int num, float[] data){
		double[] dataD = new double[data.Length];
		for(int i=0;i<data.Length;i++){
			dataD[i] = data[i];
		}

			sendAnalogData(name,port,num,dataD);

	}

	public static  void sendButtonInfo(string name, int port, int num, int[] data){
		
			sendButtonData(name,port,num,data);

	}

	public static  void sendTrackerInfo(string name, int port, int sensor, float[] pos, float[] quat){
		double[] posD = new double[pos.Length];
		double[] quatD = new double[quat.Length];
		for(int i=0;i<3;i++){
			posD[i] = pos[i];
			quatD[i] = quat[i];
		}
		quatD[3] = quat[3];

			sendTrackerData(name,port,sensor,posD,quatD);

	}
	
}




