using UnityEngine;
using UnityEngine.TestTools;
using System.Collections.Generic;
using NUnit.Framework;
using System.Collections;

public class ScoreMasterTest
{
    private ScoreMaster scoreMaster;
    private List<int> pinDrops;
    private List<int> results;
 
    [SetUp]
    public void SetUp()
    {
        scoreMaster = new ScoreMaster();
        pinDrops = new List<int>();
        results = new List<int>();
    }
    [Test]
    public void T01OnePinCountReturnsOneScore()
    {
        pinDrops.Add(1);
        results.Add(1);
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));
    }
    [Test]
    public void T02TwoPinCountNoSpareReturnsthreeNumbers()
    {
        pinDrops.Add(4);
        pinDrops.Add(5);
        results.Add(4);
        results.Add(5);
        results.Add(9);
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));
    }

}
