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
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        List<Message> GetListDrafts(string p);
        List<Message> GetListTrash(string p);

    }
}
