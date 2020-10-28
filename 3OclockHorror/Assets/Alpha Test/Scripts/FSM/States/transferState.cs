﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="IdleState", menuName = "FSM/States/Idle", order = 1)] //make object creatable
public class idleState : abstractFSMState
{
    List<room> Rooms;
    room ChosenRoom;

    public override void OnEnable() //Ovveride on enable, set state to idle
    {
        base.OnEnable();
        StateType = FSMStateType.TRANSFER;
    }
    public override bool enterState() //Enter state, once entered set duration to 0
    {
        enteredState = base.enterState();
        ChooseRoom();
        
        return enteredState;
    }

    public override void updateState() //Update state, check if we have been going too long at this point?
    {
        if (enteredState && ChosenRoom != null)
        {
            executor.transform.position = ChosenRoom.getEntrancePoint().gameObject.transform.position;
            executor.curPoint = ChosenRoom.getEntrancePoint();
            executor.pTime = 0f;
            executor.myRoom = ChosenRoom;
            fsm.enterState(FSMStateType.IDLE);
        }
        else
        {
            fsm.enterState(FSMStateType.IDLE);
            executor.pTime = 0f;
        }
    }

    public override bool exitState() //Exit the state
    {
        base.exitState();
        return true;
    }

    public void ChooseRoom()
    {
        Rooms.Clear();
        int pRow = 0;
        int pCol = 0;

        for (int i = 0; i < executor.rooms.rows.Length; i++)
        {
            for (int j = 0; j < executor.rooms.rows[i].row.Length; j++)
            {
                if (executor.rooms.rows[i].row[j] == player.myRoom)
                {
                    pRow = i;
                    pCol = j;
                }
            }
        }

        bool added = false;
        if (executor.rooms.rows[pRow--].row[pCol] != null)
        {
            Rooms.Add(executor.rooms.rows[pRow--].row[pCol]);
            added = true;
        }
        if (executor.rooms.rows[pRow++].row[pCol] != null)
        {
            Rooms.Add(executor.rooms.rows[pRow++].row[pCol]);
            added = true;
        }
        if (executor.rooms.rows[pRow].row[pCol--] != null)
        {
            Rooms.Add(executor.rooms.rows[pRow].row[pCol--]);
            added = true;
        }
        if (executor.rooms.rows[pRow].row[pCol++] != null)
        {
            Rooms.Add(executor.rooms.rows[pRow].row[pCol++]);
            added = true;
        }

        if (added)
        {
            int rand = Random.Range(0, Rooms.Count - 1);
            ChosenRoom = Rooms[rand];
            while(ChosenRoom == player.myRoom || ChosenRoom == executor.myRoom)
            {
                rand = Random.Range(0, Rooms.Count - 1);
                ChosenRoom = Rooms[rand];
            }
            Debug.Log("Chosen Room: " + ChosenRoom.getName());
        }
    }
}
