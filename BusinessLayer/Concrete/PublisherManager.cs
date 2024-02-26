using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PublisherManager:IPublisherService
    {
        IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public Publisher GetById(int id)
        {
            return _publisherDal.GetById(id);
        }

        public List<Publisher> GetList()
        {
            return _publisherDal.GetListAll();
        }

		public void PublisherAdd(Publisher publisher)
        {
            _publisherDal.Insert(publisher);
        }

        public void PublisherRemove(Publisher publisher)
        {
            _publisherDal.Delete(publisher);
        }

        public void PublisherUpdate(Publisher publisher)
        {
            _publisherDal.Update(publisher);
        }
    }
}
