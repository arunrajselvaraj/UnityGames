using UnityEngine;
using System.Collections;

public class ClickInvokeBtn : MonoBehaviour 
{
	public MonoBehaviour m_script ;
	public string m_methodName = "" ;
	private float m_delay = 0.05f ;
	
	void Start () 
	{
	
	}
	
	void OnMouseUp () 
	{
		//Debug.Log ("UP CLICKED" ) ;
		m_script.Invoke( m_methodName , m_delay ) ;
	}
	
	
}
