using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "New Card", menuName = "Card")]
public class OldCard : ScriptableObject  {

	public EffectType effecttype;
	public  CardType type;
	public UseType useType;
	public bool reserve;
	public bool wrath;
	public int level;
	public int crewNumber;
	public int rollResult;
	public ResolvedType resolved;
	public bool ignore=false;
	public bool IgnoreDeadliness;
	public bool markApolloBow;
	public bool markOrpheusLyre;
	private string name;
	private int [] difficulty;
	private int [] deadliness;
	public Sprite Sprite { get; set; }

	public string GetDescription()
	{
		return name;
	}

	
	
	public int GetCurrentDifficulty() {
		int basicDifficulty=this.difficulty[this.level];
		
		return basicDifficulty;
	}

	
	public int getCurrentDeadliness() {
		int basicDead=this.deadliness[this.level];
		return basicDead;
	}
}

public enum ResolvedType
{
	notresolved,
	resolved_win,
	resolved_lost
}

public enum UseType
{
	single,
	continuous
}

public enum CardType
{
	monster,
	treasure,
	blessing,
	wrath,
}

public enum EffectType
{
	Defeat_ColchianDragon_single,
	WingedSandals_ReturnAdventureCard_single,
	Cornucopia_Recover2Crew_single,
	PansFlute_DiscardTop2Cards_single,
	OrpheusLyre_StopLevelUpMonsterInVictoryPile_single,
	HelmOfHades_MoveMonsterToDiscardPile_single,
	Ambrosia_Recover3Crew_single,
	AegisOfZeus_IgnoreDeadliness_single,
	ApolloBow_RollDice6_single,
	CloakOfHeracles_monsterdifficulty_m1_cont,
	PoseydonTrident_ConvertWrathToBlessing_cont,
	Argo_TreasureRolls_p1_cont,
	SwordOfPeleus_MonsterRolls_p1_cont,
	DaedalusWing_RerollDieOncePerTurn_cont,
	Ignore_Scylla,
	Mirrored_Shield,
	Ignore_Charybdis
}
