using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeMonBase : ScriptableObject
{
	[SerializeField] string name;
	
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
	Sapphire,
	Silver,
	Gold,
	Light,
	Dark,
	Beast,
	Spirt,
	Demon,
	Earth,
}