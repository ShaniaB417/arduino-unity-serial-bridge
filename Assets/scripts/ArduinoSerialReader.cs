using UnityEngine;
using System.IO.Ports;

public class ArduinoSerialReader : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("/dev/cu.usbmodem1101", 9600); // Replace with your actual port
    public GameObject targetSphere;

    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 100;
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine().Trim();
                Debug.Log("Received: " + data);

                if (targetSphere != null)
                {
                    if (data == "ON")
                        targetSphere.GetComponent<Renderer>().material.color = Color.red;
                    else if (data == "OFF")
                        targetSphere.GetComponent<Renderer>().material.color = Color.white;
                }
            }
            catch (System.Exception) { }
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort.IsOpen)
            serialPort.Close();
    }
}
