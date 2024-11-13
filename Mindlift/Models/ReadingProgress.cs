using Mindlift.Models;
using System.ComponentModel.DataAnnotations;

public class ReadingProgress
{
    [Key]
    public int ReadingId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string BookTitle { get; set; }

    public int TotalBooksRead { get; set; }
    public bool Completed { get; set; } = false;
    public string MilestoneLevel { get; set; }

    public ReadingProgress()
    {
        TotalBooksRead = 1;
    }

    public void MarkAsCompleted(User user)
    {
        if (!Completed)
        {
            Completed = true;
            CompletionDate = DateTime.Now;

            TotalBooksRead += 1;

            MilestoneLevel = DetermineMilestoneLevel(TotalBooksRead);
        }
    }

    public static string DetermineMilestoneLevel(int totalBooksRead)
    {
        if (totalBooksRead >= 10)
            return "Platinum";
        if (totalBooksRead >= 5)
            return "Gold";
        if (totalBooksRead >= 3)
            return "Silver";
        if (totalBooksRead >= 1)
            return "Bronze";
        return "None";
    }
}
