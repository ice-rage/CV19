﻿using CV19.Models.Deanery;
using CV19.Services.Base;

namespace CV19.Services.Deanery
{
    internal class StudentRepository : Repository<Student>
    {
        public StudentRepository() : base(TestData.Students)
        {
            
        }

        protected override void Update(Student source, Student destination) => 
            destination = (Student)source.Clone();
    }
}
