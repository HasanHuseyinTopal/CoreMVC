using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public List<Comment> GetAllByBlogID(int ID)
        {
            return _commentDal.GetAll(x => x.BlogID == ID);
        }

        public Comment GetByID(int ID)
        {
            return _commentDal.Get(x=> x.CommentID==ID);
        }
    }
}
