using System;
using System.Collections.Generic;
using System.Linq;
using TodoBLL.Abstract;
using TodoDAL.Entities;
using UnitOfWorkRepository;

namespace TodoBLL.Concrete
{
    public class TodoRepository : ITodoRepository
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public TodoRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public TodoItem GetById(int id)
        {
            TodoItem item = _unitOfWork.Repository<TodoItem>().FindById(id);
            return item;
        }
        public object GetAll()
        {
            var obj = _unitOfWork.Repository<TodoItem>().Query().Get().ToList();
            return obj;
        }

        public void Save()
        {
            var obj = new List<TodoItem> {
                new TodoItem{ Id = 1, Name = "Assignment 1", IsComplete = false},
                new TodoItem{ Id = 2, Name = "Exam 1", IsComplete = false },
                new TodoItem{ Id = 3, Name = "Class 1", IsComplete = false }
            };

            foreach (TodoItem item in obj)
            {
                _unitOfWork.Repository<TodoItem>().Insert(item);
            }
            _unitOfWork.Save();
        }


    }
}
