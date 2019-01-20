using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
	[Header("Experience")]
	public float experience;

	public float maxExperience = 10; //Here you set any value for the xp needed to levelup for the first time, that will multiply differently based on the level
	public int level;

	[Header("UI")]
	public Text levelDisplay;

	public Slider experienceBar;

	private void Start()
	{
		experience = 0;
		level = 1;
	}

	private void Update()
	{
		experienceBar.value = experience;
		experienceBar.maxValue = maxExperience;
		levelDisplay.text = "Level: " + level;
		NextLevel();
	}

	private void NextLevel()
	{
		if (experience >= maxExperience)
		{
			LevelUp();
		}
	}

	private void LevelUp()
	{
		//Some levelup animation
		level += 1;
		experience = 0;
		maxExperience *= (1.5f - (level / 250)); //The lower the number(the one that level divides to), the easier it is to levelup
	}

	private void GiveXp(int xp) //Use this method to give the player xp
	{
		experience += xp;
		experienceBar.value += xp;
	}

	public void TestOne()
	{
		GiveXp(2);
	}

	public void TestTwo()
	{
		GiveXp(200);
	}
}