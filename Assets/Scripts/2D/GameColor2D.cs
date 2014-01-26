using UnityEngine;
using System.Collections;

public class GameColor2D{
	
	public static GameColor2D red = new GameColor2D(GameObjectColor2D.RED);
	public static GameColor2D green = new GameColor2D(GameObjectColor2D.GREEN);
	public static GameColor2D blue = new GameColor2D(GameObjectColor2D.BLUE);
	public static GameColor2D yellow = new GameColor2D(GameObjectColor2D.YELLOW);
	public static GameColor2D purple = new GameColor2D(GameObjectColor2D.PURPLE);
	
	public GameObjectColor2D color { set; get; }
	public Material textureMaterial { set; get; }
	
	public enum GameObjectColor2D {
		RED, GREEN, BLUE, YELLOW, PURPLE
	}
	
	private GameColor2D(GameObjectColor2D color) {
		this.color = color;
		switch(color) 
		{
		case GameObjectColor2D.RED:
			textureMaterial = Resources.Load<Material>("redMaterial2D");
			break;
		case GameObjectColor2D.BLUE:
			textureMaterial = Resources.Load<Material>("blueMaterial2D");
			break;
		case GameObjectColor2D.GREEN:
			textureMaterial = Resources.Load<Material>("greenMaterial2D");
			break;
		case GameObjectColor2D.PURPLE:
			textureMaterial = Resources.Load<Material>("purpleMaterial2D");
			break;
		case GameObjectColor2D.YELLOW:
			textureMaterial = Resources.Load<Material>("yellowMaterial2D");
			break;
		}
	}
}
