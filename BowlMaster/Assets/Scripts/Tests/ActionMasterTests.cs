using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


[TestFixture]
public class ActionMasterTests
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private List<int> pinDrops;
    [SetUp]
    public void Setup()
    {
        pinDrops = new List<int>(); 
     
    }

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsendTurn()
    {

        pinDrops.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinDrops));
    }
    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        pinDrops.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinDrops));     
    }
    [Test]
    public void T03Bows28SparelReturnsEndTurn()
    {
        pinDrops.Add(2);
        pinDrops.Add(8);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinDrops));   
    }
    [Test]
    public void T04CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T05CheckResetAtSpareInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,9 };       
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T06RolsInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2,9 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T07CheckEndgameAtLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1 }; 
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T08CheckTidyAtStrikeOn19InLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,5 };              
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T09CheckTidyAtgutterball20InLastFrame()
    {        
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,0 };       
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T10EndGameOnPerfectGame()
    {
        int[] rolls = { 10,10,10,10,10,10,10,10,10,10,10,10 };  
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

}
