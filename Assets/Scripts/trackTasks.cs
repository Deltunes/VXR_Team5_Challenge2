using UnityEngine;

public class trackTasks : MonoBehaviour
{
    public bool laundryDone;
    public bool clothesDone;
    public bool teethDone;

    private void Start()
    {
        laundryDone = false;
        clothesDone = false;
        teethDone = false;
    }

    public void checkProgress()
    {
        if (laundryDone == true && clothesDone == true && teethDone == true)
        {
            print("Tasks complete!");
        }
    }
}
