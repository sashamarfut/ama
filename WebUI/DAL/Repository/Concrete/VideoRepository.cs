using DAL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Concrete
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        string s = "ss";
    }
}
