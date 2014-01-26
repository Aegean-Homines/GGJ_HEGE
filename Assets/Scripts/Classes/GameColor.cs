using UnityEngine;
using System.Collections;

public class GameColor{

	public static GameColor red = new GameColor(GameObjectColor.RED);
	public static GameColor green = new GameColor(GameObjectColor.GREEN);
	public static GameColor blue = new GameColor(GameObjectColor.BLUE);
	public static GameColor yellow = new GameColor(GameObjectColor.YELLOW);
	public static GameColor purple = new GameColor(GameObjectColor.PURPLE);

	public GameObjectColor color { set; get; }
	public Material textureMaterial { set; get; }

	public enum GameObjectColor {
		RED, GREEN, BLUE, YELLOW, PURPLE
	}

	private GameColor(GameObjectColor color) {
		this.color = color;
		switch(color) 
		{
		case GameObjectColor.RED:
			textureMaterial = Resources.Load<Material>("redMaterial");
			break;
		case GameObjectColor.BLUE:
			textureMaterial = Resources.Load<Material>("blueMaterial");
			break;
		case GameObjectColor.GREEN:
			textureMaterial = Resources.Load<Material>("greenMaterial");
			break;
		case GameObjectColor.PURPLE:
			textureMaterial = Resources.Load<Material>("purpleMaterial");
			break;
		case GameObjectColor.YELLOW:
			textureMaterial = Resources.Load<Material>("yellowMaterial");
			break;
		}
	}
}
