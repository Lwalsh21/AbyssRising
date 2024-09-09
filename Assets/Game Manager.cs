using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static: GameManager Instance;
	
	[SerializeField] private float time = 0.1f;
	
	[SerializeField] private bool isPlayerTurn = true;
	
	public bool IsPlayerTurn { get => IsPlayerTurn; }
	
    
    void Awake()
    {
      if (instance == null)
	  {
	  	instance = null;
	  }  
	  else
	  {
	  	Destroy(gameObject);
	  }
    }
	
	private void start() {
		Instantate(Resources.load<GameObject>("Player")).name = "Player";
	}
	
	private IEnumerator WaitForTurns()
	{
		yield return new WaitForSeconds(time);
		isPlayerTurn = true;
	}
}
