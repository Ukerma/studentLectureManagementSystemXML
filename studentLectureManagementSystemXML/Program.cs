using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace StudentLecturerManagementSystemXML
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentID { get; set; }
        public List<string> EnrolledCourses { get; set; } = new List<string>();
    }

    public class Instructor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public List<string> AssignedCourses { get; set; } = new List<string>();

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public class Course
    {
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string InstructorName { get; set; }
        public List<string> EnrolledStudents { get; set; } = new List<string>();
    }

    class Program
    {
        static List<Student> students = LoadFromXml<List<Student>>("students.xml") ?? new List<Student>();
        static List<Instructor> instructors = LoadFromXml<List<Instructor>>("instructors.xml") ?? new List<Instructor>();
        static List<Course> courses = LoadFromXml<List<Course>>("courses.xml") ?? new List<Course>();

        static void Main(string[] args)
        {
            string choice;

            do
            {
                Console.Clear();
                Console.WriteLine("════════════════ Student and Lecture Management System ════════════════");
                Console.WriteLine("» 1. Student Management");
                Console.WriteLine("» 2. Instructor Management");
                Console.WriteLine("» 3. Course Management");
                Console.WriteLine("» 4. Exit");
                Console.Write("» Make your choice (1-4): ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageStudents();
                        break;
                    case "2":
                        ManageInstructors();
                        break;
                    case "3":
                        ManageCourses();
                        break;
                    case "4":
                        SaveAllData();
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (choice != "4")
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

            } while (choice != "4");
        }

        static void ManageStudents()
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("════════════════ Student Management ════════════════");
                Console.WriteLine("» 1. Add New Student");
                Console.WriteLine("» 2. Edit Student");
                Console.WriteLine("» 3. Delete Student");
                Console.WriteLine("» 4. List Students");
                Console.WriteLine("» 5. Assign/Remove Courses for Student");
                Console.WriteLine("» 6. Back to Main Menu");
                Console.Write("» Make your choice (1-6): ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        EditStudent();
                        break;
                    case "3":
                        DeleteStudent();
                        break;
                    case "4":
                        ListStudents();
                        break;
                    case "5":
                        ManageStudentCourses();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != "6");
        }

        static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("» Add New Student");
            Console.Write("» First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("» Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("» Student ID: ");
            string studentID = Console.ReadLine();

            students.Add(new Student { FirstName = firstName, LastName = lastName, StudentID = studentID });
            SaveToXml(students, "students.xml");
            Console.WriteLine("Student added successfully!");
        }

        static void EditStudent()
        {
            Console.Clear();
            Console.WriteLine("» Edit Student");
            ListStudents();
            Console.Write("» Select a student to edit (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index > 0 && index <= students.Count)
            {
                index--;
                Console.Write("» New First Name (current: {0}): ", students[index].FirstName);
                students[index].FirstName = Console.ReadLine();
                Console.Write("» New Last Name (current: {0}): ", students[index].LastName);
                students[index].LastName = Console.ReadLine();
                Console.Write("» New Student ID (current: {0}): ", students[index].StudentID);
                students[index].StudentID = Console.ReadLine();

                SaveToXml(students, "students.xml");
                Console.WriteLine("Student updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void DeleteStudent()
        {
            Console.Clear();
            Console.WriteLine("» Delete Student");
            ListStudents();
            Console.Write("» Select a student to delete (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index > 0 && index <= students.Count)
            {
                index--;
                students.RemoveAt(index);
                SaveToXml(students, "students.xml");
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void ManageStudentCourses()
        {
            Console.Clear();
            Console.WriteLine("» Assign/Remove Courses for Student");
            ListStudents();
            Console.Write("» Select a student (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int studentIndex) && studentIndex > 0 && studentIndex <= students.Count)
            {
                studentIndex--;
                Console.WriteLine("» 1. Assign Course");
                Console.WriteLine("» 2. Remove Course");
                Console.Write("» Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AssignCourseToStudent(studentIndex);
                }
                else if (choice == "2")
                {
                    RemoveCourseFromStudent(studentIndex);
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void AssignCourseToStudent(int studentIndex)
        {
            ListCourses();
            Console.Write("» Select a course to assign (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int courseIndex) && courseIndex > 0 && courseIndex <= courses.Count)
            {
                courseIndex--;
                var selectedCourse = courses[courseIndex];
                students[studentIndex].EnrolledCourses.Add(selectedCourse.CourseName);
                selectedCourse.EnrolledStudents.Add(students[studentIndex].StudentID);
                SaveAllData();
                Console.WriteLine("Course assigned successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void RemoveCourseFromStudent(int studentIndex)
        {
            var studentCourses = students[studentIndex].EnrolledCourses;
            if (studentCourses.Count == 0)
            {
                Console.WriteLine("This student is not enrolled in any courses.");
                return;
            }

            Console.WriteLine("» Enrolled Courses:");
            for (int i = 0; i < studentCourses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {studentCourses[i]}");
            }
            Console.Write("» Select a course to remove (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int courseIndex) && courseIndex > 0 && courseIndex <= studentCourses.Count)
            {
                courseIndex--;
                var courseName = studentCourses[courseIndex];
                studentCourses.RemoveAt(courseIndex);
                courses.Find(c => c.CourseName == courseName).EnrolledStudents.Remove(students[studentIndex].StudentID);
                SaveAllData();
                Console.WriteLine("Course removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void ListStudents()
        {
            Console.Clear();
            Console.WriteLine("» List Students");
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine("{0}. {1} {2} (ID: {3})", i + 1, students[i].FirstName, students[i].LastName, students[i].StudentID);
                    if (students[i].EnrolledCourses.Count > 0)
                    {
                        Console.WriteLine("   Enrolled Courses:");
                        foreach (var course in students[i].EnrolledCourses)
                        {
                            Console.WriteLine("   - " + course);
                        }
                    }
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void ManageInstructors()
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("════════════════ Instructor Management ════════════════");
                Console.WriteLine("» 1. Add New Instructor");
                Console.WriteLine("» 2. Edit Instructor");
                Console.WriteLine("» 3. Delete Instructor");
                Console.WriteLine("» 4. List Instructors");
                Console.WriteLine("» 5. Assign/Remove Courses for Instructor");
                Console.WriteLine("» 6. Back to Main Menu");
                Console.Write("» Make your choice (1-6): ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddInstructor();
                        break;
                    case "2":
                        EditInstructor();
                        break;
                    case "3":
                        DeleteInstructor();
                        break;
                    case "4":
                        ListInstructors();
                        break;
                    case "5":
                        ManageInstructorCourses();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != "6");
        }

        static void AddInstructor()
        {
            Console.Clear();
            Console.WriteLine("» Add New Instructor");
            Console.Write("» First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("» Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("» Department: ");
            string department = Console.ReadLine();

            instructors.Add(new Instructor { FirstName = firstName, LastName = lastName, Department = department });
            SaveToXml(instructors, "instructors.xml");
            Console.WriteLine("Instructor added successfully!");
        }

        static void EditInstructor()
        {
            Console.Clear();
            Console.WriteLine("» Edit Instructor");
            ListInstructors();
            Console.Write("» Select an instructor to edit (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index > 0 && index <= instructors.Count)
            {
                index--;
                Console.Write("» New First Name (current: {0}): ", instructors[index].FirstName);
                instructors[index].FirstName = Console.ReadLine();
                Console.Write("» New Last Name (current: {0}): ", instructors[index].LastName);
                instructors[index].LastName = Console.ReadLine();
                Console.Write("» New Department (current: {0}): ", instructors[index].Department);
                instructors[index].Department = Console.ReadLine();

                SaveToXml(instructors, "instructors.xml");
                Console.WriteLine("Instructor updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void DeleteInstructor()
        {
            Console.Clear();
            Console.WriteLine("» Delete Instructor");
            ListInstructors();
            Console.Write("» Select an instructor to delete (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index > 0 && index <= instructors.Count)
            {
                index--;
                instructors.RemoveAt(index);
                SaveToXml(instructors, "instructors.xml");
                Console.WriteLine("Instructor deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void ManageInstructorCourses()
        {
            Console.Clear();
            Console.WriteLine("» Assign/Remove Courses for Instructor");
            ListInstructors();
            Console.Write("» Select an instructor (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int instructorIndex) && instructorIndex > 0 && instructorIndex <= instructors.Count)
            {
                instructorIndex--;
                Console.WriteLine("» 1. Assign Course");
                Console.WriteLine("» 2. Remove Course");
                Console.Write("» Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AssignCourseToInstructor(instructorIndex);
                }
                else if (choice == "2")
                {
                    RemoveCourseFromInstructor(instructorIndex);
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void AssignCourseToInstructor(int instructorIndex)
        {
            ListCourses();
            Console.Write("» Select a course to assign (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int courseIndex) && courseIndex > 0 && courseIndex <= courses.Count)
            {
                courseIndex--;
                var selectedCourse = courses[courseIndex];
                instructors[instructorIndex].AssignedCourses.Add(selectedCourse.CourseName);
                selectedCourse.InstructorName = instructors[instructorIndex].GetFullName();
                SaveAllData();
                Console.WriteLine("Course assigned successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void RemoveCourseFromInstructor(int instructorIndex)
        {
            var instructorCourses = instructors[instructorIndex].AssignedCourses;
            if (instructorCourses.Count == 0)
            {
                Console.WriteLine("This instructor is not assigned to any courses.");
                return;
            }

            Console.WriteLine("» Assigned Courses:");
            for (int i = 0; i < instructorCourses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {instructorCourses[i]}");
            }
            Console.Write("» Select a course to remove (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int courseIndex) && courseIndex > 0 && courseIndex <= instructorCourses.Count)
            {
                courseIndex--;
                var courseName = instructorCourses[courseIndex];
                instructorCourses.RemoveAt(courseIndex);
                courses.Find(c => c.CourseName == courseName).InstructorName = null;
                SaveAllData();
                Console.WriteLine("Course removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void ListInstructors()
        {
            Console.Clear();
            Console.WriteLine("» List Instructors");
            if (instructors.Count == 0)
            {
                Console.WriteLine("No instructors found.");
            }
            else
            {
                for (int i = 0; i < instructors.Count; i++)
                {
                    Console.WriteLine("{0}. {1} {2} (Department: {3})", i + 1, instructors[i].FirstName, instructors[i].LastName, instructors[i].Department);
                    if (instructors[i].AssignedCourses.Count > 0)
                    {
                        Console.WriteLine("   Assigned Courses:");
                        foreach (var course in instructors[i].AssignedCourses)
                        {
                            Console.WriteLine("   - " + course);
                        }
                    }
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void ManageCourses()
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("════════════════ Course Management ════════════════");
                Console.WriteLine("» 1. Add New Course");
                Console.WriteLine("» 2. Edit Course");
                Console.WriteLine("» 3. Delete Course");
                Console.WriteLine("» 4. List Courses");
                Console.WriteLine("» 5. Back to Main Menu");
                Console.Write("» Make your choice (1-5): ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCourse();
                        break;
                    case "2":
                        EditCourse();
                        break;
                    case "3":
                        DeleteCourse();
                        break;
                    case "4":
                        ListCourses();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != "5");
        }

        static void AddCourse()
        {
            Console.Clear();
            Console.WriteLine("» Add New Course");
            Console.Write("» Course Name: ");
            string courseName = Console.ReadLine();
            Console.Write("» Credits: ");
            int credits = int.Parse(Console.ReadLine());

            courses.Add(new Course { CourseName = courseName, Credits = credits });
            SaveToXml(courses, "courses.xml");
            Console.WriteLine("Course added successfully!");
        }

        static void EditCourse()
        {
            Console.Clear();
            Console.WriteLine("» Edit Course");
            ListCourses();
            Console.Write("» Select a course to edit (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index > 0 && index <= courses.Count)
            {
                index--;
                Console.Write("» New Course Name (current: {0}): ", courses[index].CourseName);
                courses[index].CourseName = Console.ReadLine();
                Console.Write("» New Credits (current: {0}): ", courses[index].Credits);
                courses[index].Credits = int.Parse(Console.ReadLine());

                SaveToXml(courses, "courses.xml");
                Console.WriteLine("Course updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void DeleteCourse()
        {
            Console.Clear();
            Console.WriteLine("» Delete Course");
            ListCourses();
            Console.Write("» Select a course to delete (1-N): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index > 0 && index <= courses.Count)
            {
                index--;
                courses.RemoveAt(index);
                SaveToXml(courses, "courses.xml");
                Console.WriteLine("Course deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void ListCourses()
        {
            Console.Clear();
            Console.WriteLine("» List Courses");
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
            }
            else
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine("{0}. {1} (Credits: {2}, Instructor: {3})", i + 1, courses[i].CourseName, courses[i].Credits, courses[i].InstructorName ?? "Unassigned");
                    if (courses[i].EnrolledStudents.Count > 0)
                    {
                        Console.WriteLine("   Enrolled Students:");
                        foreach (var student in courses[i].EnrolledStudents)
                        {
                            Console.WriteLine("   - " + student);
                        }
                    }
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // XML Utilities
        static void SaveToXml<T>(T data, string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        static T LoadFromXml<T>(string filePath)
        {
            if (!File.Exists(filePath)) return default;
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        static void SaveAllData()
        {
            SaveToXml(students, "students.xml");
            SaveToXml(instructors, "instructors.xml");
            SaveToXml(courses, "courses.xml");
        }
    }
}
