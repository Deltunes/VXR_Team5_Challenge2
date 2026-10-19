using UnityEngine;

public class trackTasks : MonoBehaviour
{
    public bool laundryDone;
    public bool clothesDone;
    public bool teethDone;
    public bool allTasksComplete;

    private void Start()
    {
        laundryDone = false;
        clothesDone = false;
        teethDone = false;
    }

    public void checkProgress()
    {
        print("Progress check!\nlaundry: " + laundryDone + "\nclothes: " + clothesDone + "\nteeth: " + teethDone);
        if (laundryDone == true && clothesDone == true && teethDone == true)
        {
            print("Tasks complete!");
            allTasksComplete = true;
        }
    }
}
