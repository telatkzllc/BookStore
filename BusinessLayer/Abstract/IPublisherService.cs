using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPublisherService
    {
        void PublisherAdd(Publisher publisher);
        void PublisherRemove(Publisher publisher);
        void PublisherUpdate(Publisher publisher);
        List<Publisher> GetList();
        Publisher GetById(int id);
    }
}
