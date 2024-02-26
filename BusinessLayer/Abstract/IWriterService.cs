using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        void WriterAdd(Writer writer);
        void WriterRemove(Writer writer);
        void WriterUpdate(Writer writer);
        List<Writer> GetList();
        Writer GetById(int id);
    }
}
