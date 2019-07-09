﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo { get; private set; }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            switch (args[0])
            {
                case "Create":
                    CreateStudents(args);
                    break;
                case "Show":
                    ShowStudent(args);
                    break;
                case "Exit":
                    Exit();
                    break;
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void ShowStudent(string[] args)
        {
            var name = args[1];

            if (Repo.ContainsKey(name))
            {
                var student = Repo[name];
                
            }
        }

        private void CreateStudents(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);

            if (!Repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Repo[name] = student;
            }
        }
    }
}