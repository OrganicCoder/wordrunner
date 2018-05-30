using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class ColorStringConversionScript : MonoBehaviour
	{
        public static Color stringToColor(string param)
        {
			// Validate hexadecimal color length
			if(param.Length != 6 && param.Length != 8)
			{
				Debug.LogWarning("stringToColor: \"" + param + "\" has a length of " + param.Length + " but expected 6 or 8. Returning white color.");
				return new Color(1f,1f,1f);
			}
			else
			{
				float r, g, b, a = 1;
				r = hexToFloat(param.Substring(0,2));
				g = hexToFloat(param.Substring(2,2));
				b = hexToFloat(param.Substring(4,2));

				// Set alpha if one exists
				if(param.Length == 8) a = hexToFloat(param.Substring(6,2));
				// Debug.Log("Converted hex color '" + param + "' to " + new Color(r,g,b,a));
				return new Color(r,g,b,a);
			}
		}

		// Scalar conversion of hexadecimal value from the range 0-255 to 0-1
		private static float hexToFloat(string hex)
		{
			if(hex.Length != 2)
			{
				Debug.LogError("hexToFloat: Unable to convert string \"" + hex + "\" as the length is not 2.");
				return 0;
			}
			else
			{
				// Convert the number expressed in base-16 to an integer.
    			int value = Convert.ToInt32(hex, 16);
				float scalarValue = (float) value/255;
				// Debug.Log("Conversion -- hex:" + hex + ", value:" + value + ", scalarValue:" + scalarValue);
				return scalarValue;
			}
		}
	}
}
