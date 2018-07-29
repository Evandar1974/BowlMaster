using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ActionMasterTests
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster actionMaster = new ActionMaster();
    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsendTurn()
    {
        
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }
    [Test]
    public void T03TwoBowslReturnsReset()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }



    
 
}
