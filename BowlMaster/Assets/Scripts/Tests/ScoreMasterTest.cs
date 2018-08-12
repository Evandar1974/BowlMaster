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
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));
    }
    [Test]
    public void T02TwoPinCountNoSpareReturnsthreeNumbers()
    {
        pinDrops.Add(4);
        pinDrops.Add(5);
        results.Add(9);
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));
    }
    [Test]
    public void T03SingleStrikeReturnsNoScore()
    {
        pinDrops.Add(10);
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));
    }
    [Test]
    public void T04TwoStrikesReturnsNoScore()
    {
        pinDrops.Add(10);
        pinDrops.Add(10);
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));
    }
    [Test]
    public void T05ThreeStrikesReturnsOneFrameScore()
    {
        pinDrops.Add(10);
        pinDrops.Add(10);
        pinDrops.Add(10);
        results.Add(30);
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));
    }
    [Test]
    public void T06FourBallsNoStrikesTwoResults()
    {
        int[] balls = [3, 5, 6, 2];
        int[] frames = [8, 8];
        foreach(int i in balls)
        {
            pinDrops.Add(i);
        }
        foreach(int i in frames)
        {
            results.Add(i);

        }
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));

    }
    [Test]
    public void T07FullGameNoStrikesOrSpares()
    {
        int[] balls = [3, 5, 6, 2, 5, 3, 6, 1, 8, 0, 7, 2, 6, 3, 3, 5, 4, 5, 4, 5];
        int[] frames = [8, 8, 8, 7, 8, 9, 9, 8, 9, 9];
        foreach (int i in balls)
        {
            pinDrops.Add(i);
        }
        foreach (int i in frames)
        {
            results.Add(i);

        }
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));

    }
    [Test]
    public void T08FourBallsNoStrikesTwoResults()
    {
        int[] balls = [3, 5, 6, 2];
        int[] frames = [8, 8];
        foreach (int i in balls)
        {
            pinDrops.Add(i);
        }
        foreach (int i in frames)
        {
            results.Add(i);

        }
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));

    }
    [Test]
    public void T09FourBallsNoStrikesTwoResults()
    {
        int[] balls = [3, 5, 6, 2];
        int[] frames = [8, 8];
        foreach (int i in balls)
        {
            pinDrops.Add(i);
        }
        foreach (int i in frames)
        {
            results.Add(i);

        }
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));

    }
    [Test]
    public void T10FourBallsNoStrikesTwoResults()
    {
        int[] balls = [3, 5, 6, 2];
        int[] frames = [8, 8];
        foreach (int i in balls)
        {
            pinDrops.Add(i);
        }
        foreach (int i in frames)
        {
            results.Add(i);

        }
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));

    }
    [Test]
    public void T11FourBallsNoStrikesTwoResults()
    {
        int[] balls = [3, 5, 6, 2];
        int[] frames = [8, 8];
        foreach (int i in balls)
        {
            pinDrops.Add(i);
        }
        foreach (int i in frames)
        {
            results.Add(i);

        }
        Assert.AreEqual(results, scoreMaster.ScoreFrames(pinDrops));

    }
}
