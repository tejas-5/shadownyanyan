using UnityEngine;
using UnityEngine.UI;

public class CheckOrder : MonoBehaviour
{
    public Transform[] slots; // Slot1 ถึง Slot5
    public string[] correctOrder = { "1", "2", "3", "4", "5" };

    public void CheckAnswer()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].childCount == 0) return;

            string childName = slots[i].GetChild(0).name;
            if (!childName.Contains(correctOrder[i]))
            {
                Debug.Log("Incorrect!");
                return;
            }
        }

        Debug.Log("Correct! Puzzle Solved!");
        // สามารถเปลี่ยนไป Scene อื่น / ปลดล็อก / แสดงผลลัพธ์ได้ตรงนี้
    }
}