using System.Diagnostics;
using System.Reflection;
using UnityEngine;

public static class Toolbox {
	static bool enabled = true;

	public static void Log(string message) {
		if (!enabled) { return;}
			
		StackFrame frame = new StackFrame(1);
		MethodBase method = frame.GetMethod();
		string tag = method.DeclaringType.ToString();

		UnityEngine.Debug.Log (tag + ": " + message);
	}


	public static GameObject Create(string resourceName) {
		GameObject newGO = Resources.Load<GameObject>(resourceName);
		newGO = GameObject.Instantiate<GameObject>(newGO);
		newGO.name = resourceName;
		return newGO;
	}
}
