using System;
using TodoDAL.Entities;

namespace TodoBLL.Abstract
{
    public interface ITodoRepository : IDisposable
    {
        object GetAll();
        TodoItem GetById(int id);
        void Save();
    }
}
