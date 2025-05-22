using System;
using System.Xml.Linq;

namespace Student_Management_System
{
    class Student
    {
        public List<Course> Courses = new List<Course>();
        public int StudentId;
        public string Name;
        public int Age;



        public Student(int studentId, string name, int age)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Age = age;

        }

        public string PrintDetails()
        {
            return ($"ID: {StudentId}, Name: {Name}, Age: {Age} ");

        }
    }
    class Instructor
    {

        public int InstructorId;
        public string Name;
        public string Specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            this.InstructorId = instructorId;
            this.Name = name;
            this.Specialization = specialization;
        }
        public string PrintDetails()
        {
            return ($"InstructorId: {InstructorId} ,InstructorName: {Name} ,Specialization: {Specialization}");
        }
    }
    class Course
    {

        public int CourseId;
        public string Title;
        public Instructor instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            this.CourseId = courseId;
            this.Title = title;
            this.instructor = instructor;
        }
        public string PrintDetails()
        {
            return ($"CourseId: {CourseId}, Title: {Title}, Instructor: {instructor.PrintDetails()} ");
        }
    }
    class StudentManager
    {
        List<Student> Students;
        List<Course> Courses;
        List<Instructor> Instructors;
        public StudentManager()
        {
            Students = new();
            Courses = new();
            Instructors = new();
        }
        public bool AddStudent(Student student1)
        {
            if (student1.Name is null)
            {
                return false;
            }
            Students.Add(student1);
            return true;
        }
       
        public void AddCourse(Course course)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    Console.WriteLine("this course added before!");
                    return;
                }
               
            }
            Courses.Add(course);
            Console.WriteLine($"{course.PrintDetails()}Added succfully!");


        }

        public Student? FindtheStudentbyIdorName(int StuId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (StuId == Students[i].StudentId)
                {
                    return Students[i];
                }
            }
            return null;
        }

        public void ViewAllStudent()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("no student yet");

            }
            else
            {
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine(Students[i].PrintDetails());
                }
            }
        }
        public void UpdateInformation(int StuId)
        {
            Student? student = FindtheStudentbyIdorName(StuId);
            if (student == null)
            {
                Console.WriteLine("student not found");
                return;
            }
            Console.WriteLine("student data:");
            Console.WriteLine(student.PrintDetails());
            Console.WriteLine("enter new name");
            string newname = Console.ReadLine();
            if (newname is null)
            {
                Console.WriteLine("please enter valid name");
            }
            else
            {
                student.Name = newname;
            }



            Console.WriteLine("please enter valid age");
            int newage = Convert.ToInt32(Console.ReadLine());
            student.Age = newage;
            Console.WriteLine($"student {student.Name} updeted!");

        }
        public bool DeleteaStudent(int studentdelete)
        {
            for (int i = 0; i < Students.Count; i++)
            {

                if (studentdelete == Students[i].StudentId)
                {

                    Console.WriteLine($"Done you delet the student!{Students[i].PrintDetails()}");
                    Students.RemoveAt(i);
                    return true;
                }



            }

            Console.WriteLine("the is no id like this");
            return false;

        }

        public void AddNewInsta(Instructor instructor)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructor.InstructorId)
                {
                    Console.WriteLine("this instuctor added before!");
                    return;
                }
               
            }
             
                Instructors.Add(instructor);
                Console.WriteLine($"{instructor.PrintDetails()}Added succfully!");


            
        }
        public void EnrollaStudentinaCourse(int idStudent5, int idcour)
        {
            Student? student1 = null;
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == idStudent5)
                {
                    student1 = Students[i];
                    break;

                }

            }
            if (student1 == null)
            {
                Console.WriteLine("student not found.");
                return;
            }
            Course? course = null;
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == idcour)
                {
                    course = Courses[i];
                    break;
                }
            }
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            for (int i = 0; i < student1.Courses.Count; i++)
            {
                if (student1.Courses[i].CourseId == idcour)
                {
                    Console.WriteLine("Student already enrolled in this course.");
                    return;
                }
            }
            student1.Courses.Add(course);
            Console.WriteLine($"Student {student1.Name} enrolled in course {course.Title} successfully.");
        }
        public void ViewallCourses()
        {
            for(int i=0; i < Courses.Count; i++)
            {
                Console.WriteLine(Courses[i].PrintDetails());
            }
        }
        public void ViewallInstructorss()
        {
            for(int i = 0; i < Instructors.Count; i++)
            {
                Console.WriteLine(Instructors[i].PrintDetails());
            }
        }

    }

        internal class Program
        {
            static void Main(string[] args)
            {
                StudentManager studentManager = new();


                string choice;
                do
                {
                    Console.WriteLine("\n*** Student Management System ***\n");

                    Console.WriteLine("1.Add a new Student");
                    Console.WriteLine("2.View all Students");
                    Console.WriteLine("3.Search for a Student by ID");
                    Console.WriteLine("4.Update Student Information");
                    Console.WriteLine("5.Delete a Student");
                    Console.WriteLine("6.Add a new Course");
                    Console.WriteLine("7.Add a new Instructor");
                    Console.WriteLine("8.Enroll a Student in a Course");
                    Console.WriteLine("9.View all Courses");
                    Console.WriteLine("10.View all Instructors");
                    Console.WriteLine("11.Exit");

                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("enter the student id:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("enter the student name: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter sudent age: ");
                            int age = Convert.ToInt32(Console.ReadLine());

                            Student student1 = new Student(id, name, age);
                            studentManager.AddStudent(student1);

                            Console.WriteLine($"Student{student1.PrintDetails()} added successfully.\n");
                            break;

                        case "2":
                            studentManager.ViewAllStudent();
                            break;

                        case "3":
                            Console.WriteLine("Enter the student id to search: ");
                            int StuId = Convert.ToInt32(Console.ReadLine());
                            Student? student2 = studentManager.FindtheStudentbyIdorName(StuId);
                            if (student2 != null)
                            {
                                Console.WriteLine(student2.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("invalid id");
                            }
                            break;

                        case "4":
                            Console.WriteLine("enter the id  for the sudent you need to update his information");
                            int information = Convert.ToInt32(Console.ReadLine());
                            studentManager.UpdateInformation(information);



                            break;
                        case "5":
                            Console.WriteLine("enter the student id you want to delete");
                            int studentdelete = Convert.ToInt32(Console.ReadLine());
                            studentManager.DeleteaStudent(studentdelete);
                            break;

                        case "6":
                            Console.WriteLine("enter the course id you need to add");
                            int courseId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Course Title:");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter instructor  id:");
                            int instructorId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Instructor Name:");
                            string instructorName = Console.ReadLine();

                            Console.WriteLine("Enter Instructor Specialization:");
                            string specialization = Console.ReadLine();
                            Instructor instructor = new Instructor(instructorId, instructorName, specialization);
                            Course course = new Course(courseId, title, instructor);
                            studentManager.AddCourse(course);
                            Console.WriteLine(course.PrintDetails());


                            break;

                        case "7":
                            Console.WriteLine("please enter the id for new Instructor you need to add ");
                            int instructorId2 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Instructor Name:");
                            string instructorName2 = Console.ReadLine();
                            Console.WriteLine("Enter Instructor Specialization:");
                            string specialization3 = Console.ReadLine();
                            Instructor instructor5 = new Instructor(instructorId2, instructorName2, specialization3);
                            studentManager.AddNewInsta(instructor5);
                            break;
                        case "8":
                            Console.WriteLine("enter the id of Student you need to enroll in a Course");
                            int idStudent5 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("enter the course id you need to add this student to");
                            int idcour = Convert.ToInt32(Console.ReadLine());

                            studentManager.EnrollaStudentinaCourse(idStudent5, idcour);
                            break;
                        case "9":
                       studentManager.ViewallCourses();
                        break;
                    case "10":
                        studentManager.ViewallInstructorss();
                        break;
                    case "11":
                            Console.WriteLine("Exiting...");
                            return;


                        default:
                            Console.WriteLine("Unknown selection, please try again");
                            break;
                    }

                }
                while (choice != "Exit");
            }
        }
    }


