using System;
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

	public static bool NearlyEqual(double a, double b, double epsilon) {
		double absA = Math.Abs(a);
		double absB = Math.Abs(b);
		double diff = Math.Abs(a - b);

		if (a == b) { 
			// shortcut, handles infinities
			return true;
		} 
		else if (a == 0 || b == 0 || diff < Double.Epsilon) {
			// a or b is zero or both are extremely close to it
			// relative error is less meaningful here
			return diff < epsilon;
		}
		else { 
			// use relative error
			return diff / (absA + absB) < epsilon;
		}
	}
}
