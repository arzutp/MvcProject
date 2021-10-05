using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
        Message GetById(int id);
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetListDrafts();
        List<Message> GetListTrash();

    }
}
