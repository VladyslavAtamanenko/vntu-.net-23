using AVladyslav.TaskPlanner.Domain.Models;

namespace AVladyslav.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            var itemsAsList = items.ToList();
            itemsAsList.Sort(CompareWorkItems);
            return itemsAsList.ToArray();
        }
        public static int CompareWorkItems(WorkItem firstItem, WorkItem secondItem)
        {
            // Compare by Priority (descending)
            int priorityComparison = secondItem.Priority.CompareTo(firstItem.Priority);
            if (priorityComparison != 0)
                return priorityComparison;

            // Compare by DueDate (ascending)
            int dueDateComparison = firstItem.DueDate.CompareTo(secondItem.DueDate);
            if (dueDateComparison != 0)
                return dueDateComparison;

            // Compare by Title (alphabetical)
            return string.Compare(firstItem.Title, secondItem.Title, StringComparison.Ordinal);
        }
    }
}