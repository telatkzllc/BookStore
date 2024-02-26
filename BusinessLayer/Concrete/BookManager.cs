using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        //public BookManager()
        //{
        //    efBookRepository = new EfBookRepository();
        //}

        //Üstündeki ile arasında ki fark

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void BookAdd(Book book)
        {
            _bookDal.Insert(book);
        }

        public void BookRemove(Book book)
        {
            _bookDal.Delete(book);
        }

        public void BookUpdate(Book book)
        {
            _bookDal.Update(book);
        }

		public List<Book> GetBookListWithPublisherAndWriter()
		{
			return _bookDal.GetListWithPublisherAndWriter();
		}

		public Book GetById(int id)
        {
            return _bookDal.GetById(id);
        }

        public List<Book> GetList()
        {
            return _bookDal.GetListAll();
        }
    }
}
