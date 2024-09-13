using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetsMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]

public class PokeMonBase : ScriptableObject
{
	[SerializeField] string name;
	
	[TextAreas]
	[SerializeField] string description;
	
	[SerializeField] string frontSprite;
	[SerializeField] string backSprite;
	
	[SerializeField] PokemonType type1;
	[SerializeField] PokemonType type2;
	
	[SerializeField] int maxHp;
	[SerializeField] int attack;
	[SerializeField] int defense;
	[SerializeField] int spAttack;
	[SerializeField] int spDefense;
	[SerializeField] int speed;


}

public enum PokemonType
{
	Ruby,
	Emerald,
	Sapphire,
	Silver,
	Gold,
	Light,
	Dark,
	Beast,
	Spirt,
	Demon,
}