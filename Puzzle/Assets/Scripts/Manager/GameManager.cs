using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	
	public enum E_GameState
	{
		E_Init,
		E_StartGame,
		E_StopGame,
		E_None
	}
	[HideInInspector]
	public E_GameState m_GameState = E_GameState.E_None ;
	
	public SceneController m_SceneController ;
	
	#region GET SET Methods
	
	public void SetGameState (  E_GameState state_ )
	{
		m_GameState = state_ ; 
		UpdateGameState () ;
	}

	#endregion
	

	private void Start () 
	{
		SetGameState ( E_GameState.E_Init ) ;
	}
	
	
	/// <summary>
	/// Updates the State's of the game.
	/// </summary>
	private void UpdateGameState () 
	{
		switch ( m_GameState )
		{
			case E_GameState.E_Init:
				m_GameState = E_GameState.E_None ;
				Initilize() ;
				break ;
			
			case E_GameState.E_StartGame:
				m_GameState = E_GameState.E_None ;
				StartGame() ;
			break ;
			
			case E_GameState.E_StopGame:
				m_GameState = E_GameState.E_None ;
				StopGame ();
			break ;
			
			case E_GameState.E_None:
				break ;
		}
	}
	
	private void Initilize()
	{
		m_SceneController.PreSetUp () ;
		Log.InConsole( " Initilize Completed !! ", Log.E_Level.E_High ) ;
	}
	
	private void StartGame()
	{
		Log.InConsole( " Game Started !! ", Log.E_Level.E_High ) ;
		
		m_SceneController.StartGame () ;
	}
	
	private void StopGame ()
	{
		m_SceneController.ShowWinScreen () ;
		Log.InConsole( " Game Completed !! ", Log.E_Level.E_High ) ;
	}
	
	
	
}
