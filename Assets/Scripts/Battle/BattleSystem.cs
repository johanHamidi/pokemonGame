using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {Start, PlayerAction, PlayerMove, EnemyMove, Busy}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;


    private void Start()
    {
       SetupBattle();
    }

    public void SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

       StartCoroutine(dialogBox.TypeDialog($"Le Pokemon {playerUnit.Pokemon.Base.Name} apparait."));
    }
    
}
