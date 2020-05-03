using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour 
{
	
	public GameManager m_GameManager ;
	
	void Start () 
	{
	
	}
	
	public void OnStartGameBtn () 
	{
		Log.InConsole( " START GAME BUTTON CLICKED !! ", Log.E_Level.E_High ) ;
		m_GameManager.SetGameState ( GameManager.E_GameState.E_StartGame ) ;
	}
	
	public void OnPreviewBtn ()
	{
		Log.InConsole( " SHOW PREVIEW BUTTON CLICKED !! ", Log.E_Level.E_High ) ;
		m_GameManager.m_SceneController.ShowPreviwImage () ;
	}
	
	public void OnExitBtn ()
	{
		Log.InConsole( " EXIT BUTTON CLICKED !! ", Log.E_Level.E_High ) ;
		Application.Quit() ;
	}
}
