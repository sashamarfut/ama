using DAL.Repository.Abstract;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Concrete
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
    }
}
