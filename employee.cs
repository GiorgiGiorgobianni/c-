﻿using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create an ArrayList to store Lecturer objects
        ArrayList lecturers = new ArrayList();

        // Add Lecturer objects to the ArrayList
        lecturers.Add(new Lecturer("John Doe", "12345678901", 5, 10));
        lecturers.Add(new Lecturer("Jane Smith", "98765432109", 8, 8));
        lecturers.Add(new Lecturer("Michael Johnson", "45678901234", 3, 15));

        // Sort by NumberOfIssuesPublished descending
        lecturers.Sort(new IssuesPublishedComparer());
        PrintSortedLecturers("Sorted by Issues Published:", lecturers);

        // Sort by Name ascending
        lecturers.Sort(new NameComparer());
        PrintSortedLecturers("Sorted by Name:", lecturers);

        // Sort by YearsOfExperience descending
        lecturers.Sort(new YearsOfExperienceComparer());
        PrintSortedLecturers("Sorted by Years of Experience:", lecturers);
    }

    public class Lecturer
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int NumberOfIssuesPublished { get; set; }
        public int YearsOfExperience { get; set; }

        public Lecturer(string name, string id, int issuesPublished, int yearsOfExperience)
        {
            Name = name;

            if (id.Length == 11)
            {
                Id = id;
            }
            else
            {
                throw new ArgumentException("ID number must be 11 characters long.");
            }
            NumberOfIssuesPublished = issuesPublished;
            YearsOfExperience = yearsOfExperience;
        }
    }

    // Custom comparer for sorting by NumberOfIssuesPublished descending
    public class IssuesPublishedComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Lecturer lecturer1 = (Lecturer)x;
            Lecturer lecturer2 = (Lecturer)y;

            // Compare by NumberOfIssuesPublished descending
            int result = lecturer2.NumberOfIssuesPublished.CompareTo(lecturer1.NumberOfIssuesPublished);
            if (result == 0)
            {
                // If NumberOfIssuesPublished is the same, compare by Name ascending
                result = lecturer1.Name.CompareTo(lecturer2.Name);
                if (result == 0)
                {
                    // If Name is also the same, compare by YearsOfExperience descending
                    result = lecturer2.YearsOfExperience.CompareTo(lecturer1.YearsOfExperience);
                }
            }
            return result;
        }
    }

    // Custom comparer for sorting by Name ascending
    public class NameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Lecturer lecturer1 = (Lecturer)x;
            Lecturer lecturer2 = (Lecturer)y;

            // Compare by Name ascending
            int result = lecturer1.Name.CompareTo(lecturer2.Name);
            if (result == 0)
            {
                // If Name is the same, compare by NumberOfIssuesPublished descending
                result = lecturer2.NumberOfIssuesPublished.CompareTo(lecturer1.NumberOfIssuesPublished);
                if (result == 0)
                {
                    // If NumberOfIssuesPublished is also the same, compare by YearsOfExperience descending
                    result = lecturer2.YearsOfExperience.CompareTo(lecturer1.YearsOfExperience);
                }
            }
            return result;
        }
    }

    // Custom comparer for sorting by YearsOfExperience descending
    public class YearsOfExperienceComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Lecturer lecturer1 = (Lecturer)x;
            Lecturer lecturer2 = (Lecturer)y;

            // Compare by YearsOfExperience descending
            int result = lecturer2.YearsOfExperience.CompareTo(lecturer1.YearsOfExperience);
            if (result == 0)
            {
                // If YearsOfExperience is the same, compare by NumberOfIssuesPublished descending
                result = lecturer2.NumberOfIssuesPublished.CompareTo(lecturer1.NumberOfIssuesPublished);
                if (result == 0)
                {
                    // If NumberOfIssuesPublished is also the same, compare by Name ascending
                    result = lecturer1.Name.CompareTo(lecturer2.Name);
                }
            }
            return result;
        }
    }

    // Method to print sorted Lecturer objects
    static void PrintSortedLecturers(string header, ArrayList lecturers)
    {
        Console.WriteLine(header);
        foreach (Lecturer lecturer in lecturers)
        {
            Console.WriteLine($"Name: {lecturer.Name}, ID: {lecturer.Id}, Issues Published: {lecturer.NumberOfIssuesPublished}, Years of Experience: {lecturer.YearsOfExperience}");
        }
        Console.WriteLine();
    }
}