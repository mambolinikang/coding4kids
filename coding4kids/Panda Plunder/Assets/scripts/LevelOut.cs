using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOut : MonoBehaviour {

    public EndGame ender;
    public gameData DB;
    public gameScore GS;
    public questionControl QC;

    public string nextLevel;

    public int maxScore;
    public int levelNum;

    public bool endLevel;

    private void Start()
    {
        DB = FindObjectOfType<gameData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!DB.PI.levelData[levelNum].played)
        {
            DB.PI.levelData[levelNum].played = true;
            DB.PI.levelLock++;
            

        }
        else
        {

            nextLevel = "Menus/levelSelect";

        }

        if (endLevel)
        {

            nextLevel = "Menus/LevelSelect";
            //DB.openMod = 1;
        }
        

        if (GS.score == maxScore)
        {
            DB.PI.levelData[levelNum].score = GS.score;
            DB.PI.levelData[levelNum].stars = 3;
        }
        else if(GS.score > DB.PI.levelData[levelNum].score)
        {
            DB.PI.levelData[levelNum].score = GS.score;
            DB.PI.levelData[levelNum].stars = (3*GS.score)/maxScore;

        }
        for (int i = 0; i < QC.questionsAnswered; i++)
        {
            QuestionData QD = DB.PI.questionData[QC.indexes[i]];
            QD.times.Add(System.DateTime.Now.ToString());
            switch (QC.answers[i])
            {
                case 1:
                    QD.answers += "A";
                    break;
                case 2:
                    QD.answers += "B";
                    break;
                case 3:
                    QD.answers += "C";
                    break;
                case 4:
                    QD.answers += "D";
                    break;
            }

        }
        ender.endLevel(nextLevel);

    }


}
