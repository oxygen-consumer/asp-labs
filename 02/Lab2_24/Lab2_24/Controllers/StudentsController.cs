﻿using Lab2_24.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_24.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Ana", Age = 21},
            new Student { Id = 2, Name = "Maria", Age = 19},
            new Student { Id = 3, Name = "Vlad", Age = 22},
            new Student { Id = 4, Name = "Florin", Age = 25},
            new Student { Id = 5, Name = "Marian", Age = 20},
        };

        // endpoint 
        // Get 
        [HttpGet]
        public List<Student> Get()
        {
            return students.OrderBy(o => o.Age).ToList();
        }

        // Create

        [HttpPost]
        public List<Student> Add(Student student)
        {
            students.Add(student);
            return students;
        }


        [HttpDelete]
        public List<Student> Delete(Student student)
        {
            var studentIndex = students.FindIndex( x => x.Id == student.Id);
            students.RemoveAt(studentIndex);
            return students;
        }


        // Delete by ID
        [HttpDelete(Name = "DeleteByID")]
        public List<Student> DeleteById(int id)
        {
            var studInd = students.FindIndex(s => s.Id == id);
            students.RemoveAt(studInd);
            return students;
        }


        // Order by name
        [HttpGet]
        public List<Student> GetAllOrdered()
        {
            return students.OrderBy(s => s.Name).ToList();
        }
    }
}
